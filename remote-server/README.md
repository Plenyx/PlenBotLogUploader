# How to configure your own REST server to use with PlenBotLogUploader

## General rules
* if your server responds, it must respond in JSON with utf-8 encoding
* your server must be accessible from the machine from which you intent to use the uploader
* your server must be responding in http status codes

## Pinging logs
To ping logs you need to implement a REST response that would react to either GET, DELETE, PUT, POST or PATCH method requests.

You can optionally implement this JSON response structure as a server response:

    {
        "msg": (string),
    }

Where "**msg**" is used as a text response from the server and will be displayed on the main window of PlenBotLogUploader and *is a string*.

## Processing logs on the remote server
For GET and DELETE methods, the fields are encoded *within the url request* (*/?bossId=...*)

All of the data is sent as string via the url request except for the player list.

For POST and PUT methods, the fields are encoded as *application/x-www-form-urlencoded* (*/*)

These are the fields being sent:

* "**permalink**" contains a direct link to a processed log on (a/b.)dps.report *as a string*
* "**bossId**" contains the encounter (boss) id *as a string*
* "**success**" contains true if the encounter was a success, false otherwise *as a string*
* "**arcVersion**" contains the arcdps version used to create the original log *as a string*
* "**gw2Build**" contains the GW2 build on which the log was created *as a string*
* "**fightName**" contains the name of the encounter *as a string*
* "**logTimestamp**" contains the start time of the encounter *as a string*
* "**durationMs**" contains the duration of the fight in miliseconds *as a string*
* "**isEmboldened**" contains an information whether the encounter was in emboldened mode *as a string*
* "**isCM**" contains an information whether the encounter was a challenge mode *as a string*
* "**isLCM**" contains an information whether the encounter was a legendary challenge mode *as a string*
* "**players**" contains a list of account names of all players delimited by a semicolon ; *as a string*

If you opt in to be send a JSON format rather then Key=Pair values, the format would be as follows:

    {
        "permalink": (string),
        "bossId": (number),
        "success": (string),
        "arcVersion": (string),
        "gw2Build": (number),
        "fightName": (string),
        "logTimestamp": (string),
        "durationMs": (number),
        "isEmboldened": (boolean),
        "isCM": (boolean),
        "isLCM": (boolean),
        "players": (array of strings),
        "logErrors": (array of strings),
    }

* "**logErrors**" contains a list of error message EI genarated

## Other links
[HTTP Status Codes list](https://en.wikipedia.org/wiki/List_of_HTTP_status_codes)
