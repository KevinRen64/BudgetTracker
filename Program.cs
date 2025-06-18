using BudgetTracker.Models;
using BudgetTracker.Data;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography.X509Certificates;


class Program
{
    static void Main(string[] args)
    {
        // Load configuration from appsettings.json
        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appSettings.json")
            .Build();

        // Create instance of DapperStorage with config
        DapperStorage storage = new DapperStorage(config);

        while (true)
        {
            Console.WriteLine("\n=== Budget Tracker ===");
            Console.WriteLine("1. Add Transaction");
            Console.WriteLine("2. View All Transactions");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("0. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTransaction(storage);
                    break;
                case "2":
                    ViewTransaction(storage);
                    break;
                case "3":
                    ViewBalance(storage);
                    break;
                case "0":
                    //Exit
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

/// <summary>
/// Prompts the user to enter transaction details, creates a Transaction object,
/// and adds it to the database using DapperStorage.
/// Handles any input or database errors gracefully.
/// </summary>
/// <param name="storage">The DapperStorage instance used to add the transaction.</param>

    static void AddTransaction(DapperStorage storage)
    {
        try
        {
            Console.WriteLine("Datee (yyyy-MM-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Description: ");
            string description = Console.ReadLine();

            Console.WriteLine("Amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            // Create a new Transaction object with user inputs
            Transactions transaction = new Transactions
            {
                Date = date,
                Description = description,
                Amount = amount
            };
            // Add transaction to database via DapperStorage
            storage.AddTransaction(transaction);
            Console.WriteLine("Transaction added. ");
        }
        catch (Exception ex)
        {
            // Catch and display any error during input parsing or database operation
            Console.WriteLine($"Error adding transaction: {ex.Message}");
        }
    }

/// <summary>
/// Retrieves all transactions from the database and displays them in a formatted table.
/// </summary>
/// <param name="storage">The DapperStorage instance used to fetch transactions.</param>
    static void ViewTransaction(DapperStorage storage)
    {
        // Get all transactions from database
        List<Transactions> transactionList = storage.ViewAllTransactions();
        // Print header
        Console.WriteLine("\nDate\t\tDescription\t\tAmount");
        Console.WriteLine("------------------------------------------------");
        // Print each transaction's details with formatted date and currency amount
        foreach (Transactions transaction in transactionList)
        {
            Console.WriteLine($"{transaction.Date:yyyy-MM-dd}\t{transaction.Description,-20}\t{transaction.Amount:C}");
        }
    }

/// <summary>
/// Retrieves and displays the current balance (sum of all transaction amounts).
/// </summary>
/// <param name="storage">The DapperStorage instance used to fetch the balance.</param>
    static void ViewBalance(DapperStorage storage)
    {
        // Get total balance from database  
        decimal balance = storage.GetBalance();
        // Display balance formatted as currency
        Console.WriteLine($"\nCurrent Balance: {balance:C}");
    }
}
