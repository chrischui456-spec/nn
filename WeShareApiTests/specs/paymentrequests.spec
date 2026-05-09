# Payment Requests

## Create a new payment request

* Create expense for personId "1" description "Request test expense" amount "100" date "01/05/2026"
* Create request for last created expense fromPersonId "1" toPersonId "3" amount "50" to be paid by "05/05/2026"


## Create a new payment request for more than expense amount

* Create expense for personId "1" description "Over amount test expense" amount "50" date "01/05/2026"
* Post request for expenseId "2" fromPersonId "1" toPersonId "3" amount "1000" to be paid by "05/05/2026"
* Verify status code "400"
* Verify error message "Total requested amount is more than the expense amount"


## Find all payment requests

* Get all payment requests
* Check the payment request list is not empty

## Find payment requests received by a person

* Get payments request received by person with Id "3"
* Check the payment request list is not empty


## Find payment requests received by a person without requests received

* Get payments request received by person with Id "1"
* Verify that the list is empty


## Find payment requests sent by a person

* Get payments request sent by person with Id "1"
* Check the payment request list is not empty


## Find payment requests sent by a person without requests sent

* Get payments request sent by person with Id "3"
* Verify that the list is empty

## Create a new payment request for invalid expense

* Post request for expenseId "999" fromPersonId "1" toPersonId "3" amount "1" to be paid by "19/12/2026"
* Verify status code "404"
* Verify error message "Expense not found: 999"


## Create a new payment request for to yourself

* Post request for expenseId "2" fromPersonId "1" toPersonId "1" amount "0" to be paid by "19/12/2026"
* Verify status code "400"
* Verify error message "You cannot request payment from yourself"

## Find payment requests sent with invalid id

* Retrieve payments request sent by person with Id "99"
* Verify status code "404"
* Verify error message "Person not found: 99"

## Find payment requests recieved with invalid id

* Retrieve payments request received by person with Id "99"
* Verify error message "Person not found: 99"

## Pay payment request twice

* Pay payment request for last created request amount "100"
* Attempt pay payment request for last created request amount "100"
* Verify status code "400"
* Verify error message "Payment request has already been paid"


