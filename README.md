# Pargo Track & Trace .NET Core Web API

This .NET Core Web API is designed to provide package tracking information based on a waybill number. The API has a single GET request that accepts a waybill number as a query parameter and returns the package history associated with that waybill number.

## Prerequisites
Before you begin, ensure you have the following installed:

Visual Studio or Visual Studio Code
.NET SDK

## Clone the Repository
To get started, clone the PargoTrackTrace repository to your local machine using the following command:

bash
Copy code
git clone -b master https://github.com/wkapenda/pargoAPI.git
Navigate to the project directory:

bash
Copy code
cd paragoTrackTrace/server_track_trace
Run the API
Open the solution in Visual Studio or Visual Studio Code.

https://github.com/wkapenda/pargoAPI.gitBuild the solution to restore dependencies:

bash
Copy code
dotnet build
Run the API:

bash
Copy code
dotnet run
This will start the API, and you should see output indicating that the application is listening on a specific port (usually, it's http://localhost:5000).

## Open your web browser or a tool like Postman and navigate to:

plaintext
Copy code
http://localhost:5000/api/package?waybillNumber=PGO1234567
Replace PGO1234567 with the desired waybill number.

You should receive a JSON response containing the package history associated with the provided waybill number.

## API Usage
The API supports a single endpoint:

GET /api/package
Parameters:
waybillNumber (required): The waybill number to retrieve package history.
Example:
Request:
plaintext
Copy code
http://localhost:5000/api/package?waybillNumber=PGO1234567
Response:
json
Copy code
[
  {
    "status": "In transit",
    "date": "2023-01-01T10:00:00Z",
    "location": "Sample Location 1"
  },
  {
    "status": "Arrived at facility",
    "date": "2023-01-02T08:30:00Z",
    "location": "Sample Location 2"
  },
  // ... additional history entries
]

## Notes
The waybill numbers are hardcoded in the API for demonstration purposes. You can modify the DummyPackageHistories list in the PackageController to include your specific waybill numbers and associated package history.

This API is a simple demonstration and doesn't include authentication, authorization, or a database. In a production scenario, consider implementing proper security measures and storing data in a database.