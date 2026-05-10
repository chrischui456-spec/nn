# People

## Get all people returns a successful response
* Get all people
* The response is successful

## People list is not empty
* Get all people
* The people list is not empty

## Known users exist in the people list
* Get all people
* The people list contains "student1@wethinkcode.co.za"
* The people list contains "student2@wethinkcode.co.za"
* The people list contains "student3@wethinkcode.co.za"

## Login with an existing email returns success
* Login with email "student1@wethinkcode.co.za"
* The user is logged in successfully

## Login with a new email creates a new user
* Login with email "newperson_api@test.com"
* The user is logged in successfully

## New user appears in the people list after login
* Login with email "brandnew_check@test.com"
* Get all people
* The people list contains "brandnew_check@test.com"

## Login with empty email returns bad request
* Login with empty email
* The response is a bad request

## Login with invalid email format returns bad request
* Login with invalid email "not-an-email"
* The response is a bad request