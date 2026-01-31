# Twitch response variables

Twitch response variables are special pieces of text you can include in your Twitch responses to be replaced by other
dynamically generated values.

> [!IMPORTANT]
> Please understand some of these variables may be available only in the latest live release or a rolling build of the
> next release.

| Variable        | Available since | Variable description                                                                                                                                                                                                                              |
|-----------------|-----------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| `%sender%`      | r.94            | Whoever triggered the Twitch command                                                                                                                                                                                                              |
| `%channel%`     | r.94            | From whatever Twitch channel the command was triggered                                                                                                                                                                                            |
| `%appVersion%`  | r.94            | The current version of the application                                                                                                                                                                                                            |
| `%lastLog%`     | r.94            | The latest log message                                                                                                                                                                                                                            |
| `%pullCounter%` | r.94            | The current number of pulls on the last recorded log                                                                                                                                                                                              |
| `%spotifySong%` | r.94            | The currently playing song on Spotify (available only under Windows or if PlenBotLogUploader is running in the same Wine prefix as Spotify)                                                                                                       |
| `%gw2Ign%`      | r.94            | Returns the In-Game account Name for the currently played character. Requires MumbleLink setup and inserted appropriate GW2 API keys (available only under Windows or if PlenBotLogUploader is running in the same Wine prefix as Guild Wars 2)   |
| `%gw2Build%`    | r.94            | Returns the currently played build for the currently played character. Requires MumbleLink setup and inserted appropriate GW2 API keys (available only under Windows or if PlenBotLogUploader is running in the same Wine prefix as Guild Wars 2) |
