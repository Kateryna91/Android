using Microsoft.AspNetCore.Identity;

namespace Shop.Data.Entities.Identity
{
    public class AppRole : IdentityRole<long>
    {
        public virtual ICollection<AppUserRole> UserRoles { get; set; }
    }
}