<?php
/*
 * Author: Plenyx (2020)
 *
 * This php template shows a possible implementation of a remote ping functionality within PlenBotLogUploader.
 *
 * This implementation is using "POST" request method with Authorisation mode and "Bearer" scheme name.
 *
*/
header("Content-Type: application/json");
// Useful functions
function isGet() { return ($_SERVER['REQUEST_METHOD'] === "GET"); }
function isPost() { return ($_SERVER['REQUEST_METHOD'] === "POST"); }
function isPut() { return ($_SERVER['REQUEST_METHOD'] === "PUT"); }
function isDelete() { return ($_SERVER['REQUEST_METHOD'] === "DELETE"); }
function success(string $msg, int $newCode = 200) { global $response, $code; $response["msg"] = $msg; $code = $newCode; }
function fail(string $msg, $newCode = 400) { global $response, $code; $response["msg"] = $msg; $code = $newCode; }

// Authorisation definitions
$headers = apache_request_headers();
$authSplit = explode(" ", $headers["Authorization"], 2);
$authScheme = $authSplit[0];
$authToken = $authSplit[1];

// Response definitions
$response = array();
$code = 400;

// Main part of the code
if(isPost())
{
    if($scheme == "Bearer")
    {
        // clean the token before checking it (if you use mysql database, use mysqli_escape_string) 
        if ($authToken /*is correct*/)
        {
            if (IsSet($_POST["bossId"]))
            {
                /*
                    Process the log here.

                    $_POST["permalink"] - contains a direct link to a processed log on dps.report
                    $_POST["bossId"] - contains the encounter id
                    $_POST["success"] - contains "1" if the encounter was a success, "0" otherwise
                    $_POST["arcVersion"] - contains the arcdps version used to create the original log
                */
            }
            else
                success("No change"); // pingtest compatibility
        }
        else
            fail("Bearer token is invalid.", 401); // bearer token is invalid
    }
    else
        fail("Bearer token must be provided.", 401); // bearer token is not set
}
else
    fail("Unknown request.");
http_response_code($code);
echo json_encode($response);
?>
