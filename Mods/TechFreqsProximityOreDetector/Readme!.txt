


The TechFreqs Proximity Ore Detector Mod V1.4 technically v7 but whos counting, its for game version (V2.0), is a mod that adds a proximity-based ore detection in the game. With a configurable and toggleable button, when enabled, it scans the surrounding area for specific ores (Iron, Coal, Lead, Oil Deposit, and PotassiumNitrate ) displays on the screen with icon and distance. 

FunFact:
This was intended for late game and night mining with the night vision mod, but i suppose users deemed to be reliable during the day instead from previous revision but its now better!.
The ore detector mod used to require a helmet with a Night Vision Mod to function. Configurable config.json to adjust radius & keybindings but not anymore lol

Latest Changelog:
V7 a.k.a V1.4 but for game version (V2.0)
- Updated for 2.0 of 7 days to die
- Updated Readme for better information
- Updated error in 2.0 for tooltip msgs aswell as navobject code
- Added debug log troubleshooting thank you msg in logs
- Familair code from last revision but just as good
- Fixed tooltip msgs for enabling and disabling the mod with proper context
- Also detects boulder types


Overall Features:
Proximity Detection and On-Screen Display::
Scans for ores & Boulders within a configurable radius (default: 15m).
Detects Iron, Coal, Lead, Shows detected ores with icons and distance. "Ore" X.Xm (Radius: Ym) [Hot Zone]" and existing ui icons such as uses ui_game_symbol_map_treasure icon or boulders.
Enable/disable the detector with a configurable key (default: Keypad6).
Same clustering and or the ore type veins with block and distance measure how neat!


Logging:
Logs each ore type only once per session to avoid spam.
Example: [TechFreqsProximityOreDetector] Iron ore found. in F1 logs


Tooltips:
Displays a tooltip when the detector is enabled/disabled.
Enabled: [TechFreqsProximityOreDetector] Ore Detector Enabled! Happy Detecting!
Disabled: Ore Detector Disabled.


Technical Details:
Dependencies:
HarmonyLib for patching EntityPlayerLocal.Update and NavObject.IsValidPlayer.
Newtonsoft.Json for config parsing.
Game assemblies: Assembly-CSharp.dll, UnityEngine.dll.
Config: config.json in the mod folder allows customization of ToggleKey (default: Keypad6) and DetectionRadius (default: 15m, min 5m).
Slot Access: Uses EntityPlayerLocal.equipment.GetItems() to check gear, with gear[0] as the Head slot based on your log.


KNOWN BUGS OR ISSUES:
A small issue being the logs get noisy with New X type of ore found in X blocks, within a few seconds or so it isn't too spammy but needed for mod to work but thats about it really.


Disclaimer:
By using this mod, you acknowledge that TechFreq is not responsible for any issues, crashes, or conflicts caused by its use.
Use at your own risk. Please backup your game files before installing any type of mod.
Thanks for downloading and enjoy!


Installation:  
Make sure harmony mod exist in the mod directory as it's required.
Download the mod files, Extract Mod files.
Please backup your world, save, and or game files.
Place them in your Mods directory of your 7 Days to Die Game.
EAC must be disabled, although i hope in the future that can be changed, as for now DLLS are not EAC supported however XML has no issue, unfortunately this is a dll modification.
THIS IS CLIENT SIDE ONLY but maybe perhaps this is also, server side and client side compatibility?
No further setup needed. Enjoy!




CREDITS:
Thanks to TechFreq & A.I, ChatGPT or Microsoft CoPilot A.I or Grok AI from Twitter or X, for helping me create the modlet, aswell as with very little modding knowledge for the game and learning as i go i couldn't do this without it and overall brainstorming and or the modding community.
I’d very much appreciate it and or any feedback for the mod(s) aswell



Support Notice:
For those who’d like to support 'TechFreqs' work, This mod may or may not be crossposted. Downloading via 7daystodiemods website through ModsFire (ad-powered, which earns per download) and helps me a ton if posted on there or other example mod sites HOWEVER!
(although its 10 cents per download) There is also a direct mirror for using NexusMods website instead which also features direct links BUT those aren't earned per click or per downloads and run off Donation Points through a different system. The best way to support TechFreq other than downloading mods, sharing the mod with friends, leaving feedback and endorsing the mod in general is all that i ask for, but if you want to go the extra mile although not necessary you may use Donation Links through paypal or ko-fi pages which again helps me a bunch!
However, Donations aren't expected, every little bit of support helps along the way & fuels more mods, music, and bug fixes in the future,so thanks again for reading and being awesome in general and checking out the mod post.



Social Media:
If you appreciate 'TechFreqs' work and want to show support, use this donation link, although not necessary. Kofi Page: https://ko-fi.com/techfreq
I appreciate it in general for just checking out the mod posts, sharing and enjoying any of the mods in itself. Thank you again! and Happy gaming!

Love this mod? Got feedback or ideas or need to troubleshoot?
Join the TechFreq Pretty Rad Squad Discord Server! https://discord.com/invite/SQCnGjNUhw
Chill with us on Discord for game chat, memes, and even more mod updates!

As for TechFreqs music, it's royalty-free music to use in your projects or for casual listening!
Source music files are available feel free to ask away, available in the discord! or for more content! TechFreqs Socials: https://beacons.ai/techfreq

Checkout the behind-the-scenes vibes today! Thank you again for checking out the mod post.


P.S OLD versions cross posted to 7daystodiemods, so stay up to date in discord, kofi and or checkout TechFreq on nexusmods for further updates or private dms for mod suggestions and or user feedback!


Previous Changelog:
V6(v1.3) but for game version (V1.4)
Introducing clustering, ores are now clustered between types finds block calculates the amount in the area and lists a single ore chunk , within radius aswell as a hotzone for nearby the cluster.

As for V6 technically v1.2A
Changed updateInterval from 2f to 5f, so the detector updates less frequently, reducing the frequency of potential freezes.
Optimized Scanning:
Added a scanStep variable (set to 2) to sample every 2 blocks instead of every block, reducing the number of blocks checked from 29,791 to approximately 3,723 (a factor of 8 reduction).
Optimized Clustering:
Replaced the nested loop in the flood-fill algorithm with a check of only the 6 adjacent blocks (up, down, left, right, forward, backward), reducing the number of neighbor checks from 343 to 6 per block.
Used a HashSet<Vector3i> (oreBlockPositions) and a Dictionary<Vector3i, OreBlock> (oreBlocksMap) for faster lookups during clustering, avoiding the need to iterate over a list of ore blocks.
Preserved Accuracy:
The sampling approach might miss very small clusters (less than 2x2x2 blocks), but the neighbor check around detected ore blocks ensures we still find most clusters. The clusterDistance and minClusterSize settings still apply, so clusters must be at least 5 blocks to be displayed.

Added more to config json
The detectionRadius of 15 blocks might still be too large for some systems, especially in dense biomes with many ore deposits. You can reduce it in the config.json file:

{
  "ToggleKey": "Keypad6",
  "DetectionRadius": 10.0, // Reduced from 15.0 to 10.0
  "ClusterDistance": 3,
  "MinClusterSize": 5
}


As for V5 technically v1.2
same functionality without the nightvision mod required.

As for V4 technically v1.1A:
including Oil Deposits, formely oil shale and PotassiumNitrate in V1.1 as i had forgotten to include those initially too, i had the rest of ores but those two.
again ores, not boulders.
