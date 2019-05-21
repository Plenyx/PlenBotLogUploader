# How to create your own ping server

## General rules
* your server must respond in JSON with utf-8 encoding
* your server must be accessible from the machine from which you intent to use the uploader

## Ping test
For "ping test" functionality to work you need to implement JSON response structure found in PlenyxAPI/PlenyxAPIPingTest.cs.

Additionaly, your URL link needs to support /pingtest/ as the append to use the ping test.

The JSON response structure is as follows:
* status ***!***
  * code
  * msg
* error ***!***
  * code
  * msg

You can only have one of the structures marked with ***!*** in the response.

For a successful ping test the status code needs to be either 200 or 201.

## Pinging logs
To ping logs themselves you need to implement response that would react to either GET, DELETE, PUT or POST method requests.

You need to implement JSON respond structure found in PlenyxAPI/PlenyxAPIPingResponse.cs.

The JSON response structure is as follows:
* status ***!***
  * code
  * msg
* error ***!***
  * code
  * msg
* log ***?***
  * user_id
  * log_id

You can only have one of the structures marked with ***!*** in the response.

Structure marked with ***?*** is optional and only returned on successful ping.

For a successful ping the status code needs to be either 200, 201 or 204.