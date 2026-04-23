namespace FinShark.API.Models
{
    public class AuditTransaction
    {
        public int AuditTransactionId { get; set; }
        public string ApplicationUserId  { get; set; }=string.Empty;

        public string ModuleName { get; set; } = string.Empty;
        public string ActionType { get; set; }=string.Empty;
        public int ReferenceId { get; set; }
         
        public decimal Amount { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
