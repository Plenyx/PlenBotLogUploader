# PlenBotLogUploader [![Build status](https://ci.appveyor.com/api/projects/status/qdx2bmsj54yg0c0y?svg=true)](https://ci.appveyor.com/project/Plenyx/plenbotloguploader)
An open source uploader to dps.report which post the links to Twitch chat or not, depending on the setting and more.

*Maintained by Plenyx.*

**Requires .NET Framework 4.5 ([link](https://www.microsoft.com/en-us/download/details.aspx?id=30653))** - v4.6 is preinstalled on Windows 10 by default, so you don't need to download it if you own Windows 10, it is backwards compatible)**

## Installation
To install the uploader, I recommend creating a new folder and putting the executable in.

The uploader will create a file called “links.txt” which will contain all previous and latest upload links.

For the flawless experience with the bot working with Twitch I recommend giving a VIP to the username “gw2loguploader”. Do not mod it, since the bot is used by many people and everyone has access to its credentials (because of the open source code).

## Update
The uploader keeps track of its version and the online available version. When you start the executable, it will check for updates. If update is found a prompt will be displayed.

To update the bot you need to overwrite the previous version.

## Future updates
I plan to finish the following features:
* pinging logs into Discord channel
  * highly requested, currently in closed beta
  * if you want access, contact me directly, it requires manual approval and a "sign" given by me for it to work
* uploading to GW2Raidar
  * highly requested
* implementation with gw2.ninja
  * putting the commands possible by gw2.ninja to general public with zero setup requirements

## TwitchIrcClient
A client I developed for Irc which Twitch uses.

Initially built on .NET Framework 4.7, but I made it work on 4.5 and .NET Core 2.1.

*Maintained by Plenyx.*

**Requires either .NET Framework 4.5 or .NET Core 2.1**
