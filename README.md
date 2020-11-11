
Custom Death Penalty Plus allows the death penalty (and pass out penalty as of 1.1.0) to be fully customised in [Stardew Valley](https://www.stardewvalley.net/).

Current options allow configuration for:

**Death Penalty**
- Disabling item loss
- Amount of money lost, including max amount that can be lost
- Amount of health and energy to restore
- A more realistic option for dying, disabled by default

**Pass Out Penalty**
- Amount of money lost, including max amount that can be lost
- Amount of energy to restore next day

### Installation:
1. Install the latest version of SMAPI
2. Install Custom Death Penalty Plus, available [here](https://www.nexusmods.com/stardewvalley/mods/7069).
3. Extract the contents into your Mods folder
4. Run the game through SMAPI

### Usage:
1. Run the game at least once to generate the config file
2. Change any desired values in the config. Percentage values are expressed in decimal form
3. Your changes should now be implemented in game

Note: The mod will create per-savefile JSON files (found in the mod folder) if you pass out or die with WakeupNextDayinClinic enabled so that it knows what to restore if you exit the next day without saving. While deleting these will not affect the game, it can lead to incorrect values being used. Only delete the file if you are deleting the character.

### If changes are not implemented:
 - Check the mod page for accepted values
 - The mod should automatically use the default values if a config value is invalid. If your changes are not implemented check the SMAPI monitor for errors or messages.
 - WakeupNextDayinClinic will only begin a new day in single-player unless the condition removed version is downloaded, I wouldn't recommend it though, it can cause the game to become unresponsive.
 
### Versions:
1.0.0 - Initial release

1.1.0 - Passing out penalty is now fully customisable. Added config option for a more realistic death. Minor bug fixes

