# <ApplicationName>

<Description of the application>

## Prerequisites

Before running this application, ensure you have installed:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- A suitable IDE such as [Visual Studio](https://visualstudio.microsoft.com/), [VS Code](https://code.visualstudio.com/), or JetBrains Rider
- [SQLite](https://www.sqlite.org/index.html) for the database, as the project uses SQLite

## Setup

### 1. Clone the Repository

Clone the project repository and navigate into the project directory:

```bash
git clone https://github.com/marszhhx/LibraryManagement3.gitl
cd LibraryManagement3
```


### 2. Install Dependencies
Dependencies are automatically restored when you build the project. However, you can manually restore them by running:

```bash
dotnet restore
```

### 3. Database Setup
This application uses Entity Framework Core and automatically configures a SQLite database according to the connection string in appsettings.json or the environment-specific configuration file.

Apply migrations to set up the database:

```bash
dotnet ef database update
```

### 4. Google and Facebook Authentication
   The application is configured for authentication using Google and Facebook. Ensure you have the correct ClientId and ClientSecret for each service configured in the application. These should be considered sensitive information and not stored in version control. Use user secrets or environment variables for production environments.

## Running the Application
To run the application, use the following command from the project directory:

```bash
dotnet run
```

This will start the application on a local web server, typically accessible via http://localhost:5000 or https://localhost:5001.

## Running the Application
Once the application is running, you can access:
