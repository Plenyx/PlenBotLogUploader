# PlenBotLogUploader [![Build status](https://ci.appveyor.com/api/projects/status/qdx2bmsj54yg0c0y?svg=true)](https://ci.appveyor.com/project/Plenyx/plenbotloguploader)
The all-in-one solution for all your arcdps logs.

If you need any help to set-up the bot, be up-to-date with latest features or have a direct contact with other users of the uploader, you can join a special Discord server "[PlenBot support line](https://discord.gg/khMDaym)"!

*Maintained by Plenyx.*

**Requires .NET Framework 4.8 ([link](https://dotnet.microsoft.com/download/thank-you/net48))**

## Installation ([download](https://github.com/Plenyx/PlenBotLogUploader/releases))
To install the uploader, I recommend creating a new folder and putting the executable in.

The uploader will create a file called "uploaded_logs.csv" which will contain all previous and latest upload links with additional data.

For the flawless experience with the bot working with Twitch I recommend giving a VIP to the username "gw2loguploader". Do not mod it, since the bot is used by many people and everyone has access to its credentials (because of the open source code). You can also use a custom name for your bot which requires a use of another Twitch account.

If you are using the uploader with Twitch integration, you can customise bot messages in the "Edit boss data" dialog window. Settings are saved in "boss_data.txt" file.

I recommend using the compress feature in the arcdps log settings. Otherwise the bot will try to archive it itself, which delays log uploads.

## Update
The uploader keeps track of its version and the online available version.
When you start the executable, it will check for a new version. If update is available a prompt will be displayed.

To update the bot you need to overwrite the previous executable.

## Uninstall/Reinstall
To remove all application settings, remove the "PlenBotLogUploader.exe_Url_xxx" folders located in the "%AppData%\Plenyx's_Bad_Software", use "Reset all settings" button inside the application or launch the application with -resetsettings flag.

To remove all the saved logs, remove the "uploaded_logs.csv" file located in the directory of the executable.

To remove all the saved boss data, remove the "boss_data.txt" file located in the directory of the executable.

To remove all the saved Discord webhooks, remove the "discord_webhooks.txt" file located in the directory of the executable.

To remove all the saved remote server ping configurations, remove the "remote_pings.txt" file located in the directory of the executable.

To fully remove all the saved settings in the registry, use the enclosed "ResetSettings.reg" file in the release tab.

## Features
* arcdps log uploads
  * uploading arcdps logs to dps.report as soon as they are made
  * uploading arcdps logs to GW2Raidar when set up
  * drag & drop directly to the executable or to the running application itself to quickly upload a log
* log processing
  * pinging links to Discord channels (via Discord webhooks)
  * pinging log data to remote servers (via Remote server pings)
  * organise logs in log sessions
    * record all logs under one session and unleash one message with all log links to Discord channels
    * every log session has a dedicated csv file to record the session
* Twitch integration
  * pinging links to Twitch chat with customisable messages
  * custom name for the Twitch chat bot, otherwise "gw2loguploader" is being used
* update reminder & automatic update install
* arcdps auto-updater

## Future updates
I plan to finish the following features:
* *adding additional features based on feedback*
  * I am always looking to provide more features to the users, if you have any ideas of how to improve the uploader, don't be afraid to contact me directly.

## Remote server ping
Remote server ping allows you to send log data to a custom server.

If you wish to create your own server, follow the [MAKE-CUSTOM-REMOTE-SERVER-README](https://github.com/Plenyx/PlenBotLogUploader/blob/master/remote-server/README.md) readme.

## TwitchIrcClient
A client I developed for Irc which Twitch uses.

Initially built on .NET Framework 4.7, but it also works on 4.8 and .NET Core 2.1, 3.0 & 3.1.

*Maintained by Plenyx.*

**Requires either .NET Framework 4.8 or .NET Core 3.0**
