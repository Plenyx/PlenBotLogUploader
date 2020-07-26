# How to create your own remote ping server

## General rules
* your server must respond in JSON with utf-8 encoding
* your server must be accessible from the machine from which you intent to use the uploader
* your server should be responding in http status codes

## Pinging logs
To ping logs you need to implement response that would react to either GET, DELETE, PUT or POST method requests.

You need to implement this JSON response structure:

    {
      "msg": (string)
    }

Where "**msg**" is used as a text response from the server and will be displayed on the main window of PlenBotLogUploader and *is a string*.

## Processing logs on the remote server
For POST and PUT methods, the fields are encoded as *application/x-www-form-urlencoded* (*/ping/*)

For GET and DELETE methods, the fields are encoded *within the url request* (*/ping/?bossId=...*)

These are the fields being sent:

    {
      "permalink": (string),
      "bossId": (int),
      "success": (string),
      "arcVersion": (string)
    }

* "**permalink**" contains a direct link to a processed log on dps.report *as a string*
* "**bossId**" contains the encounter (boss) id *as an integer*
* "**success**" contains "1" if the encounter was a success, "0" otherwise *as a string*
* "**arcVersion**" contains the arcdps version used to create the original log *as a string*

## Remote server examples
[PHP example with post request and Authorisation header](https://github.com/DelusionalElitists/PlenBotLogUploader/blob/master/remote-server/php-remote-template.php)

## Other links
[HTTP Status Codes list](https://en.wikipedia.org/wiki/List_of_HTTP_status_codes)
