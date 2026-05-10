# Journey

## End-to-end payment flow

* Login with email "student1@wethinkcode.co.za"
* Create expense for personId "1" description "Journey expense" amount "200" date "01/05/2026"
* Create request for last created expense fromPersonId "1" toPersonId "3" amount "100" to be paid by "05/05/2026"

* Login with email "student3@wethinkcode.co.za"
* Pay payment request for last created request amount "100"
* Verify payment request is paid
* Verify payment exists for person "3"

* Login with email "student1@wethinkcode.co.za"
* Verify expense nett amount is "100"



## End-to-End: Multi-Person Bill Split

* Login with email "student1@wethinkcode.co.za"
* Capture logged in user as Student1

* Login with email "student2@wethinkcode.co.za"
* Capture logged in user as Student2

* Login with email "student3@wethinkcode.co.za"
* Capture logged in user as Student3

* Login with email "student1@wethinkcode.co.za"

* Create expense for personId "1" description "Weekend Trip" amount "1200" date "09/05/2026"

* Create request for last created expense fromPersonId "1" toPersonId "2" amount "400" to be paid by "16/05/2026"
* Create request for last created expense fromPersonId "1" toPersonId "3" amount "500" to be paid by "16/05/2026"

* Verify expense nett amount is "1200"

* Login with email "student2@wethinkcode.co.za"
* Pay payment request for last created request amount "400"

* Login with email "student3@wethinkcode.co.za"
* Pay payment request for last created request amount "500"

* Login with email "student1@wethinkcode.co.za"

* Verify expense nett amount is "300"

* Verify payment request is paid


## Simple Multi-User Settlement Flow

* Login with email "student1@wethinkcode.co.za"
* Create expense for personId "1" description "Group meal" amount "150" date "05/05/2026"
* Create request for last created expense fromPersonId "1" toPersonId "2" amount "75" to be paid by "10/05/2026"

* Login with email "student2@wethinkcode.co.za"
* Pay payment request for last created request amount "75"
* Verify payment exists for person "2"

* Login with email "student1@wethinkcode.co.za"
* Verify expense nett amount is "75"
* Verify payment request is paid