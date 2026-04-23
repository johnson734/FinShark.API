namespace FinShark.API.Models
{
    public class ExpenseTransaction
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }=string.Empty;
        public int CategoryId { get; set; }


        public decimal Amount { get; set; }
        public string PaymentMode { get; set; } = string.Empty;
        public string? Note { get; set; }

        public ApplicationUser? User { get; set; }
        public Category? Category { get; set; }
    }
}
