# Expenses

## Create a new expense

* Create expense for personId "1" description "Lunch" amount "100" date "19/12/2023"
* Check that the expense was created

## Find all expenses

* Get all expenses
* Check the expense list is not empty

## Find expense by invalid id
* Retrieve expense by id "invalid"
* Verify status code "404"
* Verify error message "Expense not found"

## Find expenses by person

* Get expenses by person id "1"
* Check the expense list is not empty

## Find expenses by person without expenses

* Get expenses by person id "4"
* Verify that the expense list is empty

## Create expense with invalid person

* Post expense for personId "99" description "Test" amount "50" date "19/12/2023"
* Verify status code "404"
* Verify error message "Person not found: 99"

## Find expense by non-existent id
* Retrieve expense by id "99999"
* Verify status code "404"
* Verify error message "Expense not found"

## Find expenses by invalid person

* Retrieve expenses by person id "99"
* Verify status code "404"
* Verify error message "Person not found: 99"


## Create expense with very large amount

* Create expense for personId "1" description "Large amount" amount "1000000" date "01/05/2026"
* Check that the expense was created