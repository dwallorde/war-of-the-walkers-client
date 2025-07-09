Bobcat Vehicle Mod for 7 Days to Die

A custom mod for 7 Days to Die that introduces a functional Bobcat-style vehicle with terrain manipulation and utility functionality.

How to use:
Equip a bucket or drill mod to the Bobcat vehicle.
Press the crouch button to change operating modes
Press the horn button to enable/disable the mode from operating
	enable/disable is used to prevent unintentional terrain changes while changing modes

Modes:
1.) Landscaping: Clears blocks 2 high in front of the vehicle at the width of the bucket attached 3 or 5 blocks wide. Best used for digging
shallow terrain, clearing debris, clearing grass/vegetation/bricks etc.

2.) Leveling: When activated, uses the current vehicle height (block height) to level terrain. The amount to level (high or low) can be configured
in the Configuration.xml file. Default levels terrain to not cover up crop plot blocks. Will level terrain in front of the vehicle based on
the installed bucket width. This mode is best used when creating a flat area to build on or wanting to flatten out an area. Disable/enable when
on a different height to change the reference height. If leveling moves to a different block height the leveling button will be outlined
in red, letting you know you're at a different height than when you last activated it. Leveling works on the activation height, this is to prevent
unintentional terrain heights when moving around on slopes.

3.) Filling: When activated uses the current vehicle height (block height) to fill in terrain below this height. Will only work if terrain blocks
(top soil etc) are placed into the vehicles inventory, the resource consumed to fill in holes is configurable in Configuration.xml . It will consume
the first matching terrain block in the inventory regardless of position in the vehicle's inventory. Best used to fill in terrain holes that are
created from exploding zombies, explosions like rockets etc. The button will be outlined in red if attempting to fill an area that is not close
to the same activation block height.

4.) Smoothing: Used to slope an incline so that vehicles may more easily drive between block heights. Best used when there is one block height on a road 
for example and it suddenly increases block height so that vehicles bottom out when attempting to drive along the road. Place the bobcat at the location
where the terrain is too steep to smooth it out which would allow vehicle travel in a less steep manner.

5.) Drilling: Only available with the drill. This mode is best used for tunneling. Will collect resources and add them to the vehicles inventory
when destroyed. Will break a 3x3 area in front of the vehicle. The vehicle will drill as long as it is not tilted to a large degree for safety reasons.

*** For more clarification, see the video list that will cover the basics of usage.

How to obtain: Find the schematics or purchase them from traders. The Bobcat vehicle itself requires 4x4 parts. The vehicle also comes with
a traction control mod made for the Bobcat, this enables superior traction but makes driving fast more difficult.

Installation
1. Download and extract the mod into your 7 Days to Die `Mods/` directory:
2. Ensure the folder structure looks like:
Mods/
└── Bobcat/
├── Harmony/
├── Resources/
├── Config/
└── ModInfo.xml

3. Launch the game. The mod should load automatically.

*** This mod requires **Harmony** (included).

Configuration
All mod options can be tweaked in Configuration.xml:
- Adjust smoothing radius
- Enable/disable block pickup
- Control tick intervals for terrain changes
- Toggle visual effects per mod

Compatibility
- Tested with 1.4 and 2.0 versions of the game
- May conflict with other mods that patch terrain modification, vehicle inventory, or EntityVehicle methods
- If using a custom vehicle mod pack, ensure no ID/name collisions (vehicleBobcat is the internal name)

This mod was developed using:
- C# with Harmony patches
- Custom Unity prefabs and animations
- Coroutine-based logic for real-time terrain updates


This mod is free to use, modify, and distribute with attribution. Please credit the original author if redistributing.
Created by: Jonathan Stanley
Github: https://github.com/jstanleyf1985