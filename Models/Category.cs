namespace FinShark.API.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string ApplicationUserId { get; set; }=string.Empty;
        public string Name { get; set; }=string.Empty;
        public string Type { get; set; }=string.Empty;//Income //Expense
        public bool IsActive { get; set; } = true;

        public ApplicationUser? User { get; set; }
    }
}
