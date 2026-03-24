using System;
using System.Collections.Generic;
// using System.Linq; // Not currently used
// using System.Text; // Not currently used
// using System.Threading.Tasks; // Not currently used
using UnityEngine;

// Represents data and actions for a single farm plot block.
public class FarmPlotData
{
    private readonly Vector3i _blockPos = Vector3i.zero; // Use readonly if set only in constructor
    public bool Visited { get; set; } = false; // Use private set if only modified internally

    public FarmPlotData(Vector3i blockPos)
    {
        this._blockPos = blockPos;
    }

    public Vector3i GetBlockPos()
    {
        return _blockPos;
    }

    /// <summary>
    /// Marks the plot as visited (e.g., by an NPC).
    /// Consider renaming if 'Visited' has multiple meanings.
    /// </summary>
    public void UpdateData() // Consider a more descriptive name like MarkVisited()
    {
        Visited = true;
    }

    /// <summary>
    /// Checks if the farm plot has access to water via pipes or nearby sources.
    /// Uses WaterPipeManager's cached lookup and PlantData's checks.
    /// </summary>
    public bool HasWater()
    {
        var plotPos = _blockPos + Vector3i.up;

        // Check pipe/direct water at plot level and one above
        if (WaterPipeManager.Instance.GetWaterForPosition(plotPos) != Vector3i.zero) return true;
        if (WaterPipeManager.Instance.GetWaterForPosition(_blockPos) != Vector3i.zero) return true;

        // Check if any active connected sprinkler covers this position.
        // Avoids creating a temp PlantData on an air block (which has no WaterRange property).
        foreach (var sprinklerPos in WaterPipeManager.Instance.GetWaterValves())
        {
            var bv = GameManager.Instance.World.GetBlock(sprinklerPos);
            if (bv.Block is not BlockWaterSourceSDX sprinkler) continue;

            float rangeSq = sprinkler.GetWaterRange() * sprinkler.GetWaterRange();
            if (Vector3.SqrMagnitude(plotPos - sprinklerPos) > rangeSq) continue;

            if (sprinkler.IsWaterSourceUnlimited() ||
                WaterPipeManager.Instance.GetWaterForPosition(sprinklerPos) != Vector3i.zero)
                return true;
        }

        return false;
    }

    /// <summary>
    /// Checks if the block directly above the farm plot is air.
    /// </summary>
    public bool IsEmpty()
    {
        var blockAbove = GameManager.Instance.World.GetBlock(_blockPos + Vector3i.up);
        return blockAbove.isair;
    }

    /// <summary>
    /// Checks if the block above the farm plot is a non-plant block (assumed dead/wilted).
    /// </summary>
    public bool IsDeadPlant()
    {
        var blockAbove = GameManager.Instance.World.GetBlock(_blockPos + Vector3i.up);
        if (blockAbove.isair) return false; // Air isn't a dead plant
        if (blockAbove.Block is BlockPlant) return false; // Living plants are not dead plants
        // Any other non-air block is considered a dead plant in this context
        return true;
    }

    /// <summary>
    /// Checks if the farm plot has any plant (living or dead) on it.
    /// </summary>
    public bool HasPlant()
    {
        if (IsEmpty()) return false;

        // Check if CropManager knows about a plant at or above the plot
        // Note: CropManager uses _blockPos + Vector3i.up frequently for plants on plots.
        if (CropManager.Instance.GetPlant(_blockPos + Vector3i.up) != null) return true;
        // Maybe also check at _blockPos itself? Depends on where plants are registered.
        // if (CropManager.Instance.GetPlant(_blockPos) != null) return true;

        // If not registered, check if it's a dead plant block type
        if (IsDeadPlant()) return true;

        // Could add a check here: Is the block above a BlockPlant, even if not registered?
        // var blockAbove = GameManager.Instance.World.GetBlock(_blockPos + Vector3i.up);
        // if (blockAbove.Block is BlockPlant) return true;

        return false;
    }

    /// <summary>
    /// Resets the Visited flag.
    /// </summary>
    public void Reset()
    {
        Visited = false;
    }

  /// <summary>
/// Logic for an NPC to manage this farm plot (harvest, clear dead plants, replant).
/// Note: This method is complex and could be a performance consideration under heavy NPC load.
/// </summary>
/// <param name="entityAlive">The NPC entity managing the plot.</param>
/// <returns>List of harvested items, or null/empty list if no harvest occurred.</returns>
public List<Block.SItemDropProb> Manage(EntityAlive entityAlive)
{
    Visited = true; // Mark as visited for this cycle
    bool shouldReplant = false;
    var plantPos = _blockPos + Vector3i.up;
    var plantData = CropManager.Instance.GetPlant(plantPos);
    var currentBlockValue = GameManager.Instance.World.GetBlock(plantPos);
    var harvestItems = new List<Block.SItemDropProb>();
    string seedFromPlant = string.Empty; // Seed item name derived from the harvested plant

    // --- Handle existing plant/block ---
    if (IsDeadPlant()) // Check if it's a dead/wilted plant block
    {
        AdvLogging.DisplayLog("FarmPlotData", $"NPC {entityAlive.entityId} clearing dead plant at {plantPos}");
        currentBlockValue = BlockValue.Air; // Update local variable; air RPC is handled in the replant block below
        shouldReplant = true;
    }
    else if (!IsEmpty() && currentBlockValue.Block != null) // If there's a non-air block (might be a plant)
    {
        // Check if it's harvestable (fully grown)
        // A plant is harvestable if it doesn't have a 'PlantGrowing.Next' property, implying it's the final stage.
        bool isHarvestable = !currentBlockValue.Block.Properties.Contains("PlantGrowing.Next");

        if (isHarvestable)
        {
             AdvLogging.DisplayLog("FarmPlotData", $"NPC {entityAlive.entityId} harvesting at {plantPos}");
             // Try to get harvest drops
            currentBlockValue.Block.itemsToDrop.TryGetValue(EnumDropEvent.Harvest, out harvestItems);
            harvestItems ??= new List<Block.SItemDropProb>(); // Ensure list is not null

            // Also add destroy drops, as harvesting removes the block
            currentBlockValue.Block.itemsToDrop.TryGetValue(EnumDropEvent.Destroy, out var destroyItems);
            if (destroyItems != null) harvestItems.AddRange(destroyItems);

            // Process harvested items: find seed, adjust counts based on NPC cvars
            for (int i = harvestItems.Count - 1; i >= 0; i--)
            {
                var item = harvestItems[i];
                // Identify the seed item associated with this plant
                if (item.name.StartsWith("planted") && seedFromPlant == string.Empty) // Take the first seed found
                {
                    seedFromPlant = item.name;
                    harvestItems.RemoveAt(i); // Remove seed from harvest list
                }
                else if (entityAlive.Buffs.HasCustomVar(item.name)) // Adjust counts based on NPC skill/cvar
                {
                    item.minCount = (int)entityAlive.Buffs.GetCustomVar(item.name);
                    item.maxCount = (int)entityAlive.Buffs.GetCustomVar(item.name);
                    harvestItems[i] = item; // Update struct in list
                }
            }

            currentBlockValue = BlockValue.Air; // Air + optional seed RPC is handled atomically in the replant block below
            shouldReplant = true;
        }
        else if (plantData != null)
        {
             // Plant exists but isn't fully grown, update its last check time?
             AdvLogging.DisplayLog("FarmPlotData", $"NPC {entityAlive.entityId} tending non-harvestable plant at {plantPos}");
        }
    }
    else // Plot is empty
    {
        shouldReplant = true;
    }

    // --- Handle Replanting ---
    if (shouldReplant)
    {
         AdvLogging.DisplayLog("FarmPlotData", $"NPC {entityAlive.entityId} checking replant for {plantPos}");
        // Check for water before attempting to replant
        if (!HasWater())
        {
             AdvLogging.DisplayLog("FarmPlotData", $"NPC {entityAlive.entityId} cannot replant at {plantPos} - no water.");
            // Still clear dead/harvested blocks so the NPC doesn't keep visiting the same plot
            if (!IsEmpty())
                GameManager.Instance.World.SetBlocksRPC(new List<BlockChangeInfo> { new BlockChangeInfo(plantPos, BlockValue.Air, false) });
            return harvestItems;
        }

        string seedToPlant = seedFromPlant; // Use seed from harvested plant first

        // If no seed from harvest, try to find one in NPC inventory
        if (string.IsNullOrEmpty(seedToPlant))
        {
            foreach (var stack in entityAlive.lootContainer.items)
            {
                if (!stack.IsEmpty())
                {
                    var itemClass = ItemClass.GetForId(stack.itemValue.type);
                    // Assuming seeds are named like "planted<CropName>1"
                    if (itemClass.Name.StartsWith("planted") && itemClass.Name.EndsWith("1"))
                    {
                        seedToPlant = itemClass.Name;
                        stack.count--; // Decrement item count in inventory
                        if (stack.count <= 0) stack.Clear(); // Clear stack if empty
                        entityAlive.lootContainer.SetModified(); // Mark inventory changed
                        break; // Found a seed
                    }
                }
            }
        }

        // Determine what to place at plantPos: seed if available, otherwise air (to clear dead/harvested block)
        BlockValue blockToPlace = BlockValue.Air;
        if (!string.IsNullOrEmpty(seedToPlant))
        {
            var seedBlock = Block.GetBlockByName(seedToPlant);
            if (seedBlock != null)
            {
                var blockValueToPlace = seedBlock.ToBlockValue();
                if (seedBlock.CanPlaceBlockAt(GameManager.Instance.World, 0, plantPos, blockValueToPlace))
                {
                    blockToPlace = blockValueToPlace;
                }
                else
                {
                    AdvLogging.DisplayLog("FarmPlotData", $"NPC {entityAlive.entityId} Cannot place {seedToPlant} at {plantPos} (CanPlaceBlockAt failed).");
                    // Return the seed so it is not silently lost
                    if (!string.IsNullOrEmpty(seedFromPlant))
                    {
                        // Seed came from the harvested plant drop — add it back to harvest items
                        harvestItems.Add(new Block.SItemDropProb { name = seedFromPlant, minCount = 1, maxCount = 1, prob = 1f });
                    }
                    else
                    {
                        // Seed was taken from NPC inventory — put it back
                        foreach (var stack in entityAlive.lootContainer.items)
                        {
                            if (!stack.IsEmpty()) continue;
                            stack.itemValue = ItemClass.GetItem(seedToPlant, false);
                            stack.count = 1;
                            entityAlive.lootContainer.SetModified();
                            break;
                        }
                    }
                }
            }
            else
            {
                AdvLogging.DisplayLog("FarmPlotData", $"NPC {entityAlive.entityId} Could not find block for seed name {seedToPlant}.");
            }
        }
        else
        {
            AdvLogging.DisplayLog("FarmPlotData", $"NPC {entityAlive.entityId} has no seed to replant at {plantPos}.");
        }

        // Send a single atomic RPC: clear the old block, then place the new one (air or seed).
        // Using two entries in one SetBlocksRPC avoids the race condition of a separate air call
        // followed by a separate seed call, where the seed could arrive before the air is processed.
        if (!IsEmpty() || !blockToPlace.isair)
        {
            AdvLogging.DisplayLog("FarmPlotData", $"NPC {entityAlive.entityId} setting {plantPos} to {blockToPlace.Block?.GetBlockName() ?? "air"}");
            GameManager.Instance.World.SetBlocksRPC(new List<BlockChangeInfo>
            {
                new BlockChangeInfo(plantPos, BlockValue.Air, false),
                new BlockChangeInfo(plantPos, blockToPlace, false)
            });
        }
    }

    return harvestItems;
}
}