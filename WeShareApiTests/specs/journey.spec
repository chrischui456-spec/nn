# Journey

## End-to-end payment flow

* Login with email "student1@wethinkcode.co.za"
* Create expense for personId "1" description "Journey expense" amount "200" date "01/05/2026"
* Create request for last created expense fromPersonId "1" toPersonId "3" amount "100" to be paid by "05/05/2026"
* Pay payment request for last created request amount "100"
* Verify expense nett amount is "100"
* Verify payment request is paid
* Verify payment exists for person "3"