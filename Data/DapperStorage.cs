using BudgetTracker.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;


namespace BudgetTracker.Data
{
  public class DapperStorage
  {
    private string _connectionString;
    // Constructor: retrieves the connection string from the configuration file
    public DapperStorage(IConfiguration config)
    {
      _connectionString = config.GetConnectionString("DefaultConnection");
    }

    // Method to insert a new transaction into the database
    public void AddTransaction(Transactions transaction)
    {
      // Create a new SQL database connection using the stored connection string
      IDbConnection dbConnection = new SqlConnection(_connectionString);
      // Define the SQL query with parameter placeholders to prevent SQL injection
      string sql = "INSERT INTO Transactions (Date, Description, Amount) VALUES (@Date, @Description, @Amount)";
      // Execute the SQL command using Dapper, passing the transaction object as parameter values
      dbConnection.Execute(sql, transaction);
    }

    public List<Transactions> ViewAllTransactions()
    {
      // Create a new SQL database connection using the stored connection string
      IDbConnection dbConnection = new SqlConnection(_connectionString);
      // Define the SQL query to retrieve all transactions
      string sql = "SELECT * FROM Transactions";
      // Execute the query and map the results to a list of Transaction objects
      return dbConnection.Query<Transactions>(sql).ToList();
    }

    public decimal GetBalance()
    {
      // Create a new SQL database connection using the stored connection string
      IDbConnection dbConnection = new SqlConnection(_connectionString);
      // Define the SQL query to calculate the total balance (sum of Amounts)
      string sql = "SELECT SUM(Amount) FROM Transactions";
      // Execute the query and return the result
      // If the result is null (e.g., no records), return 0
      return dbConnection.QuerySingleOrDefault<decimal?>(sql) ?? 0;
    }

  }

}
