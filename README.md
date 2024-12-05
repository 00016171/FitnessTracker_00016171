Fitness Tracker API
This application was developed for the Web Application module, as a coursework portfolio project @ WIUT by student ID: 00016171.

Description
The Fitness Tracker API is a web application designed to manage users and their physical activity data. The application allows users to create, update, and delete their profile information as well as log their fitness activities such as exercise duration, activity type, and distance. The application also allows querying activity history and linking it to user profiles.

Features
User Management: Add, update, and delete user profiles.
Activity Logging: Users can log various activities such as running, walking, cycling, etc.
Database: All data is stored in a relational database, with entities User and Activity having a one-to-many relationship.
Getting Started
Prerequisites
Make sure you have the following installed:

.NET 8.0 SDK or higher
SQLite for local database storage
Visual Studio or another code editor
Installation
Clone the repository:

bash
Copy code
https://github.com/00016171/FitnessTracker_00016171
cd fitness-tracker-api
Restore the NuGet packages:

bash
Copy code
dotnet restore
Apply migrations to create the database:

bash
Copy code
dotnet ef database update
Run the application:

bash
Copy code
dotnet run
Usage
Create a User: Send a POST request to /api/users with user details (e.g., first name, last name, email, date of birth).
Update a User: Send a PUT request to /api/users/{id} with updated user data.
Delete a User: Send a DELETE request to /api/users/{id}.
Add an Activity: Send a POST request to /api/activities with activity details (e.g., activity type, duration, distance).
Get User Activities: Send a GET request to /api/users/{id}/activities to retrieve activities for a user.
