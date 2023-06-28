# PlenBotLogUploader [![Build and test](https://github.com/Plenyx/PlenBotLogUploader/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/HardstuckGuild/PlenBotLogUploader/actions/workflows/build-and-test.yml) ![GitHub release (latest by date)](https://img.shields.io/github/downloads/HardstuckGuild/PlenBotLogUploader/latest/total?label=latest%20release%20downloads&style=flat-square) ![GitHub all releases](https://img.shields.io/github/downloads/HardstuckGuild/PlenBotLogUploader/total?label=total%20downloads&style=flat-square)
The all-in-one solution for all your arcdps logs.

If you need any help to set-up the bot, be up-to-date with latest features or have a direct contact with other users of the uploader, you can join a special Discord server "[PlenBot support line](https://discord.gg/khMDaym)"!

*Maintained by @Plenyx & @sobrinth.*

## Installation ([download](https://github.com/Plenyx/PlenBotLogUploader/releases)) | [Screenshots](https://plenbot.net/uploader/?utm_source=github&utm_medium=referral&utm_campaign=readme)

### **Video tutorials:** [Quick setup with Discord webhooks](https://www.youtube.com/watch?v=EsMy0yKdjXk) | [Advanced setup, Twitch, log sessions, arcdps plugin manager](https://www.youtube.com/watch?v=plGFNL4kuZY)

To install the uploader, I recommend creating a new folder and putting the executable in.

The uploader will create a file called "uploaded_logs.csv" which will contain all upload links with additional data.

For the flawless experience with the bot working with Twitch I recommend giving a VIP to the username "gw2loguploader". Do not mod it, since the bot is used by many people and everyone has access to its credentials (because of the open source code). You can also use a custom name for your bot which requires a use of another Twitch account.

If you are using the uploader with Twitch integration, you can customise bot messages in the "Edit boss data" dialog window. Settings are saved in "boss_data.json" file.

I recommend using the compress feature in the arcdps log settings. Otherwise the bot will try to archive it itself, which delays log uploads.

## Update
The uploader keeps track of its version and the vesion available online.
When you start the executable, it will check whether a new version is available.

To update the bot you either need to overwrite the previous executable with the new one under the Release tab or you need to press the big **Update Uploader** button within the application. Alternatively, you can setup an automatic update if you toggle "automatically update the uploader".

## Uninstall/Reinstall
To remove all application settings, remove the "app_settings.json" file located in the directory of the executable.

To remove all saved arcdps logs, remove the "uploaded_logs.csv" file located in the directory of the executable.

To remove all saved boss data, remove the "boss_data.json" file located in the directory of the executable.

To remove all saved teams, remove the "teams.json" file located in the directory of the executable.

To remove all saved Discord webhooks, remove the "discord_webhooks.json" file located in the directory of the executable.

To remove all saved arcdps plugin manager settings, remove the "arcdps_plugin_manager.json" file located in the directory of the executable.

To remove all saved remote server ping configurations, remove the "remote_pings.json" file located in the directory of the executable.

To fully remove all the saved settings in the Windows registry, use the enclosed "ResetSettings.reg" file in the release tab.

## Features
* arcdps log uploads
  * uploading arcdps logs to dps.report as soon as they are made (with settable userToken)
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
* Set up advanced log conditions using Teams system
  * Limit Discord Webhooks and bots to specific players in a group
    * Statics, commanders and friends...
* Aleeva & GW2Bot integration
* update reminder & automatic update install
* arcdps auto-updater and plugin manager

## Future updates
I plan to finish the following features:
* *adding additional features based on your feedback*
  * I am always looking to provide more features to the users, if you have any ideas of how to improve the uploader, don't be afraid to contact me directly.

## Remote server ping
Remote server ping allows you to send log data to a custom REST server.

If you wish to use your own REST server, follow the [remote server readme](https://github.com/Plenyx/PlenBotLogUploader/blob/main/remote-server/README.md).
