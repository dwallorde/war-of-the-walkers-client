


The TechFreq's Shared Spike Trap XP Mod, for 7 Days to Die allows players to gain XP from enemy zombies and most hostile animals killed by wooden or iron spike traps. The XP distribution is proximity-based, meaning that if a player is near the traps when a kill occurs, they will receive XP—now rocking configurable , 150 XP per kill & 30m radius file.

Latest Changelog:
V4.3
- Updated for 2.0
- Fixed message with tooltip null error
- Fixed xp not granting to player from previous version.
- Updated ReadMe! and updated modinfo for website value
- Updated logs for debug thank you and troubleshooting message in blue highlight
- Updated Folder label and modinfo for mod name values keeping things consistent


Current Functionality:
If a lone wolf’s near the spike traps, they bag 150 XP per kill—easy peasy! If a squad’s hanging out, everyone within the 20m radius scores their share—fair and square, no favoritism here! Too far? No XP for you—keeps it local and legit. Zombie dogs, bears, and other nasties? They drop XP too—tested and silky smooth! Logs confirm we all get XP when we’re close, and we *actually* see it—tooltip included for that sweet victory vibe! 


Current Status:
✅ Basic XP system shines at 150 XP per kill
✅ Multiplayer XP sharing is perfect—all nearby players cash in the same amount within distance
✅ Enemy animals like zombie dogs and bears grant XP, no glitches
✅ Flawlessly shares XP within 20m—clean, reliable, and spam-free
✅ Tooltip pops up for local players—“Gained 150 XP from spike trap kill!”


If a single player is near the spike traps, they receive XP (100 XP per kill).
If multiple players are nearby, the mod attempts to determine who to send the XP to,but if not in distance of the spike traps no xp will be givens 
If a player is far away, it will show in logs upon entity kill and determine whether or not they should recieve it
When two players are present, the logs indicate XP is awarded to both,
Improve logging and feedback so each player gets clear confirmation of earned XP in LOGs via F1
Fixed XP inconsistencies 
anything else that needs adjustments...


Installation: 
Make sure harmony mod exist in the mod directory as it's required.
Download the mod files, Extract Mod files.
Please backup your world, save, and or game files.
Place them in your Mods directory of your 7 Days to Die Game.
EAC must be disabled, although i hope in the future that can be changed, as for now DLLS are not EAC supported however XML has no issue, unfortunately this is a dll modification.
THIS IS CLIENT SIDE ONLY but maybe perhaps this is also, server side and client side compatibility?
No further setup needed. Enjoy!
TESTED CONFIRMED:
Works if client and server mod is installed simultaneously


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




Previous Changelogs:
V4.2
thanks to Zherkezhi or lazurusdemon on discord and their idea of XP Scaling via world settings and dynamically updated xp amount, despite config jsons setup

p.s dont mind the 10,000 xp, i have my loot abundance to 1 million percent for a debug world, using another mod called extended game settings, for testing.. ill upload more pics later for default xp value.. and functionality but this is a tough project as it is aswell..  but just to put that out there.

AS FOR V2 changes for 1.2 or v2.0
Verification:
All Nearby Players: The foreach loop checks every player and awards XP to each one within PROXIMITY_RADIUS (10 meters).
Not Global: If no players are within range, no XP is awarded (no global fallback).
Proximity-Based: Only players close to the trap get XP.
Example Scenario:
Spike trap at (0,0,0) kills a zombie
Player A at (5,0,0) (5m away) gets 100 XP
Player B at (8,0,0) (8m away) gets 100 XP
Player C at (15,0,0) (15m away) gets nothing
All players beyond 10m get nothing
If a spike trap kills a "zombieSoldier" at (0,0,0):
Player "Bob" at 5m: [TechFreqsSharedSpikeTrapXPMod] Bob gained 100 XP for killing zombieSoldier (Distance: 5.0m)
Player "Alice" at 8m: [TechFreqsSharedSpikeTrapXPMod] Alice gained 100 XP for killing zombieSoldier (Distance: 8.0m)
Summary: [TechFreqsSharedSpikeTrapXPMod] Shared 100 XP with 2 player(s) near trap for killing zombieSoldier.
If no players are nearby: [TechFreqsSharedSpikeTrapXPMod] No players within 10m of trap that killed zombieSoldier.
Verification:
Still awards XP to all players within 10 meters.
No global XP distribution.
Now includes the entity name (zombie or animal) in the debug logs, like your original code.

AS FOR V3 Changes for 1.3 or v3.0
Adding a config.json for adjustable radius and XP is an easy win for flexibility.
Land Claim Block Radius ALIKE DISTANCE : matchign the range to the land claim block’s distance 
(default is 41x41 meters in 7 Days to Die, centered on the block, so ~20.5m radius). This would cover all traps in your claimed area nicely.
but default to Proximity Radius of 20 meter distance and 100xp amount but with V3 its changed to 30m and 150xp but up to you!

AS FOR V4 Changes for v4.0:
Verification:- All Nearby Players: The foreach loop checks every player and awards XP to each one within PROXIMITY_RADIUS (default 30m—close to land claim’s ~20.5m if you tweak it!).- Not Global: No players in range? No XP—keeps it tight and local.
- Proximity-Based: Only trap heroes nearby get the goods! Example Scenario:Spike trap at (0,0,0) kills a zombie:- Player A at (5,0,0) (5m away) gets 150 XP- Player B at (15,0,0) (15m away) gets 150 XP- Player C at (25,0,0) (25m away) gets nada All players beyond 20m get zilch—simple and sweet!If a spike trap kills a "zombieBoe" at (0,0,0):- Player "TechFreq" at 5m: [TechFreqsSharedSpikeTrapXPMod] Awarded 150 XP to TechFreq (Distance: 5.0m)- Player "Queenserenity__" at 15m: [TechFreqsSharedSpikeTrapXPMod] Awarded 150 XP to Queenserenity__ (Distance: 15.0m)- Summary: [TechFreqsSharedSpikeTrapXPMod] Shared 150 XP with 2 player(s) for zombieBoeIf no one’s nearby:
Silence—no log clutter!
Verification:- Awards XP to all players within 20m—tested and golden across non-dedicated and dedicated servers!- No global XP nonsense—only the close crew scores.- Logs are lean—only confirmed kills and XP awards, plus entity names for that extra flavor!- Config.json keeps it flexible—default 20m radius and 150 XP, but tweak it to match land claim size (20.5m) or go wild!- Dedicated server tested—works like a charm with just the client mod installed!