using Microsoft.AspNetCore.Identity;

namespace FinShark.API.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FullName { get; set; }=string.Empty;
        public DateTime CreatedDate { get; set; } =DateTime.Now;
    }
}
