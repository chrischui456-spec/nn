# About this repo

Project Structure

weshare-qa-project/
│
├── api-tests/
│   ├── Specs/
│   ├── Steps/
│   ├── Weshare/
        ├── Client/
        └── Models/
│
├── gui-tests/
│   ├── Specs/
│   ├── Pages/
│   ├── Steps/
│
└── README.md


Pull the Docker Image
docker pull wethinkcode/weshare-qa:2022

Run the Docker Container
docker run -p 5050:5050 -d wethinkcode/weshare-qa:2022

If you want to run the application in the foreground, remove the -d flag.

Accessing the Application

Application URL:
http://localhost:5050


# Test Users
You can use the following sample users:

Email
student1@wethinkcode.co.za
student2@wethinkcode.co.za
student3@wethinkcode.co.za
Any new email address will automatically create a new user.

Running the Tests

# API Tests
Navigate to the API test project:

cd WeshareApiTests

Run the test plans:
Gauge run


# GUI Tests
Navigate to the GUI test project:

cd WeshareGuiTests

Run the test plans:
Gauge run


After execution, reports can be found in:


TestResults/
Gauge Reports

Generate Gauge HTML reports:
gauge run specs

Reports will be generated in:
reports/html-report/
Test Coverage
API Testing

# The API test suite covers:
Authentication
User creation
Item listings
Borrowing items
Returning items
Error handling
Validation testing
Negative scenarios
GUI Testing

# The GUI test suite covers:
Login journeys
User registration
Viewing available items
Lending items
Borrowing items
Returning items
Navigation flows
Validation and error messages
Testing Approach


View running containers:
docker ps

Stop a container:
docker stop <container-id>


There is no code in this repo. 
You must create your solution and projects from scratch.
whatever

## Good luck!