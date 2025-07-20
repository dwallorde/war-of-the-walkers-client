
The TechFreqs Wandering Zombie Horde Alert Mod , for 7 Days to Die, is designed to give players an early warning when specific groups of wandering enemies get too close. It enhances situational awareness by providing configurable audio-visual alerts for nearby hordes.

Latest Changelog:
V1.0 for (V2.1)BETA
- 2.1 B7 stable.


Key features include:
Proximity Alerts: The mod periodically scans the area around the player (default 50 meters) for predefined enemy groups, such as wandering zombie hordes, zombie dogs, and zombie vultures.
Customizable Notifications: When a horde (2 or more enemies from a group) is detected, it triggers:
A text tooltip on the screen with a unique message for each horde type (e.g., "I hear shuffling footsteps... a wandering zombie horde is nearby!").
A distinct audio cue (e.g., dog growl, zombie moan).
Compass icons that track the individual enemies for a set duration, showing their location.
In-Game Control: Players can easily toggle the entire alert system on or off using a hotkey (default: PageUp).
High Configurability: Almost every feature can be tweaked through a config.json file, allowing users to adjust the detection range, scan frequency, icon duration, and enable or disable sounds, compass icons, distance text, and labels.
Testing Commands: Includes console commands for easy testing:
hspawn <groupName> [count]: Spawns a specified wandering horde to test the alerts.

How It Works:
The mod uses Harmony to patch into the game's core functions. It runs a continuous background process (coroutine) that checks for entities within a set radius of the player. When it finds entities matching its predefined groups (WanderingHorde, ZombieDogGroup, etc.), it triggers the configured alerts and temporarily registers each enemy as a navigation object, making its icon appear on the player's compass. The system automatically cleans up icons for enemies that are killed, move out of range, or after a set time has passed.



CONFIG JSON:
The config.json file in its folder, allowing you to customize its behavior. If you change these settings while the game is running, you can use the reloadhordeconfig console command to apply them without restarting.
Here are the available settings and their default values:
"ToggleKey": "PageUp"
The keyboard key used to turn the alert system on and off in-game. You can use any valid Unity KeyCode name (e.g., "F8", "KeypadPlus").
"ProximityRange": 50.0
The distance in meters at which the mod will detect enemies and trigger an alert.
"EnableSound": true
Set to true to play an audio alert when a horde is detected. Set to false to disable sound alerts.
"EnableCompass": true
Set to true to show icons for detected enemies on your compass. If false, no icons will appear.
"ShowDistance": true
If compass icons are enabled, set this to true to display the distance (e.g., "45.1m") next to the enemy's label.
"ShowLabels": true
If compass icons are enabled, set this to true to display a text label (e.g., "Zombie") on the icon.
"ShowIcons": true
If compass icons are enabled, this determines if the specific horde icon (wolf, bat, etc.) is shown.
"AutoEnable": true
If true, the alert system will be active automatically when you load into a game. If false, you will need to press the ToggleKey to turn it on.
"ScanFrequency": 1.0
The time in seconds between each scan for nearby enemies. A lower number means faster detection but uses slightly more resources.
"ScanDuration": 20.0
The time in seconds that an enemy's icon will remain on the compass after being detected.
"DebugLogging": true
Enables detailed logging in the F1 console, which is useful for troubleshooting or seeing exactly what the mod is doing. It's recommended to set this to false for normal gameplay.
Of course. Here is a breakdown of the mod's configuration options and a summary of the mod's features.




EXAMPLE CONFIG JSON
{
    "ToggleKey": "PageUp",
    "ProximityRange": 20.0,
    "MaxCompassDistance": 20.0,
    "EnableSound": true,
    "EnableCompass": true,
    "ShowDistance": true,
    "ShowLabels": true,
    "ShowIcons": true,
    "DebugLogging": true,
    "VerboseDebugLogging": true,
    "AutoEnable": true,
    "ScanFrequency": 1.0,
    "ScanDuration": 20.0
}

Mod Features Summary:
This mod adds a comprehensive and customizable early-warning system for wandering hordes.
Wandering Horde Detection:
The primary feature is its ability to detect specific enemy groups before they ambush you. It is pre-configured to recognize and alert you to:
Standard Wandering Zombie Hordes
Zombie Dog Packs
Zombie Vulture Flocks
Multi-Sensory Alerts:
Visual Text: A large tooltip appears on your screen with a warning message tailored to the type of horde detected.
Audio Cues: Each horde type has a unique sound effect, allowing you to identify the threat by sound alone.
Compass Tracking: Detected enemies are marked with icons on your compass and in the world, showing their precise location and distance for a limited time. This helps you to quickly assess the threat's direction and size.
Complete Player Control:
The entire system can be toggled on or off at any time with a single key press (PageUp by default), giving you full control over when you want to use it. You can also configure it to be off by default when you start the game.
Admin & Testing Tools:
The mod includes simple console commands to help players and server admins. You can spawn test hordes on demand (hspawn) to see the alerts in action or reload the configuration file live (reloadhordeconfig) to fine-tune settings without leaving the game.


Installation: 
Make sure harmony mod exist in the mod directory as it's required.
Download the mod files, Extract Mod files.
Please backup your world, save, and or game files.
Place them in your Mods directory of your 7 Days to Die Game.
EAC must be disabled, although i hope in the future that can be changed, as for now DLLS are not EAC supported however XML has no issue
THIS IS CLIENT SIDE ONLY but maybe perhaps this is also, server side and client side compatibility?
No further setup needed. Enjoy!


Disclaimer:
By using this mod, you acknowledge that TechFreq is not responsible for any issues, crashes, or conflicts caused by its use.
Use at your own risk. Please backup your game files before installing any type of mod.
Thanks for downloading and enjoy!


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
Chill with us on Discord for game chat, memes, and even more mod updates!
Join the TechFreq Pretty Rad Squad Server! https://discord.com/invite/SQCnGjNUhw

As for TechFreqs music, it's royalty-free music to use in your projects or for casual listening!
Source music files are available feel free to ask away, available in the discord! or for more content! TechFreqs Socials: https://beacons.ai/techfreq
Checkout the behind-the-scenes vibes today! Thank you again for checking out the mod post.


License: CC BY-NC-SA 4.0  
This mod is licensed under Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International. You can use it for personal play in *7 Days to Die*. Modifications or sharing require crediting TechFreq, linking to the mod page, and using the same license for derivatives. Contact me at beacons.ai/techfreq for permission for any modifications or changes. 
See LICENSE.txt or http://creativecommons.org/licenses/by-nc-sa/4.0/ for full terms.  
Note: Monetized videos/blogs showcasing this mod are allowed along as with credit to TechFreq.


Technical Detail Summary (for Modders/Advanced Users):
Tracks only zombies spawned by the AIDirector’s Wandering Horde and Scout/Screamer Horde systems.
Uses Harmony patches:
Prefix on World.SpawnEntityInWorld to catch zombies spawned by AIWanderingHordeSpawner.UpdateSpawn.
Postfix on AIScoutHordeSpawner.SpawnUpdate to catch zombies spawned by scout/screamer hordes.
Postfix on EntityZombie.OnEntityDeath to remove zombies from tracking when they die.
Only zombies in these tracked sets get NavObject icons/labels.
Configurable detection radius, compass icon distance, and UI options.
Debug logging and verbose logging supported.
No dummy GameObjects: NavObjects are attached directly to the entity.
No icons for random zombies, only for real horde members.
