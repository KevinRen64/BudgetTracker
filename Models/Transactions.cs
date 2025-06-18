namespace BudgetTracker.Models
{
  public class Transactions
  {
    public int TransactionID { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; } = "";
    public decimal Amount { get; set; }

  }
}


