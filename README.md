# BudgetTracker

A simple console application to track financial transactions built with C#, Dapper, and SQL Server.

## Features

- Add new transactions (date, description, amount)
- View all transactions in a list
- Calculate and display current balance
- Uses Dapper micro-ORM for database access
- Configuration via `appSettings.json` for database connection

## Technologies Used

- C# (.NET 8)
- Dapper
- SQL Server
- Microsoft.Extensions.Configuration

## Getting Started

### Prerequisites

- .NET 8 SDK or later
- SQL Server (local or remote)
- Visual Studio or any C# IDE

### Setup

**1. Clone this repository:**
   
   git clone https://github.com/yourusername/BudgetTracker.git
   cd BudgetTracker

**2. Create the database and table. Use the following SQL to create your database table:**

   CREATE TABLE Transactions (
       Id INT IDENTITY(1,1) PRIMARY KEY,
       Date DATE NOT NULL,
       Description NVARCHAR(255) NOT NULL,
       Amount DECIMAL(18,2) NOT NULL
   );

**3. Configure your database connection:**

   Edit appSettings.json and update the connection string:
   
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=BudgetTracker;Trusted_Connection=True;"
     }
   }

**4. Build and run the app:**
   
   dotnet run
