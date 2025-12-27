YAML file settings
------------------

- QuestLimit
Default: 30
Maximum number of quests a trader can offer at once.
Increase this for more variety (e.g. 50), or lower it (e.g. 5) if you prefer vanilla-like scarcity.

- EnableSorting
Default: true
If enabled, quests are sorted by Tier → Distance → Alphabetical.
Set to false to keep the order they’re generated in.

- EnableClearQuestHotkey
Default: true
Enables a hotkey to clear quests from your journal.

- ClearQuestHotkey
Default: LeftShift+BackQuote
The key combination used to clear quests.

- ShowRemainingToClear
Default: true
Shows how many objectives remain to complete a quest.

- RemainingTextFormat
Default: "{0} - Remaining: {1}"
Format string for displaying remaining objectives.
{0} = quest description, {1} = remaining count.

 Notes
- Special quests (like “Visit the next trader”) are not included in the expanded list. They remain in their own dialog tree.
- If you set QuestLimit very high, you may see duplicate quest types pointing to different POIs. That’s intentional — it gives you more choice.
- If a quest cannot be positioned on the map, it will be discarded automatically as per vanilla.



🗺️ Quest Selection Flow - without bypass tier restrictions
-------------------------
1- Determine Eligible Tiers
	- Based on your progression (e.g., you’ve unlocked up to Tier 3).
	- Eligible tiers = {1, 2, 3}.
2- Pick a Tier
3- Read the Quest Pool for that Tier
	- Gather all quests at the chosen tier.
	- Example: Tier 2 has 15 possible quests.
4- Decide How Many to Show
	- show the entire pool (w/e was set).
5- Apply Sorting/Filtering
	- If Sorting = true: order by nearest first.
	- Otherwise: leave in random or default order.
6- Display to Player
	- Trader shows the final list.
	- Player picks one quest.
