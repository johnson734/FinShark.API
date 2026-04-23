namespace FinShark.API.Models
{
    public class IncomeTransaction
    {
        public int IncomeTransactionId { get; set; }
        public string ApplicationUserId { get; set; } = string.Empty;
        public int CategoryId { get; set; }

        public decimal Amount { get; set; }
        public string Source { get; set; }=string.Empty;
        public string? Note { get; set; }

        public DateTime TranDate { get; set; }=DateTime.UtcNow;
         
        
        public ApplicationUser? User { get; set; }
        public Category? Category { get; set; }
    }
}
