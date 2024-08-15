using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Coffee.Models.Entities
{
    public class User : IdentityUser
    {
        public DateTime Created { get; set; }
    }

}
