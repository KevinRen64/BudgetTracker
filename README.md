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

1. Clone this repository:

   ```bash
   git clone https://github.com/yourusername/BudgetTracker.git
   cd BudgetTracker

