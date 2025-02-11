# DesignTechHomesTest

## Create the Database

To recreate the database with schema and seed data, follow these steps:

1. Open SQL Server Management Studio (SSMS).
2. Connect to your SQL Server instance.
3. Open the `Data/Scripts/DatabaseSetup.sql` file.
4. Examine the file and make sure there's nothing in there that you don't like!
5. Execute the script.

This will create the necessary database, tables, and insert sample data for testing.


## Installation and Configuration

1. Make sure the solution folder "DesignTechHomesTest" is placed in an appropriate location.
2. Open the DesignTechHomesTest.sln file in Visual Studio.
3. Open appsettings.json and update the connection string to point to the database you previously created.


## Running the Application

1. Build and run the solution.
2. For initial login, do one of the following:
   a. Click "Register" on the right-hand side of the top navigation bar to register as a new user.
   b. Log in with these credentials:
	  TestUser1@gmail.com
	  TestPass-1
3. Click the various navigation links and test the application.
