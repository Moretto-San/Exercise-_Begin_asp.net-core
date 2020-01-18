using Microsoft.AspNetCore.Identity;

namespace CodersAcademy.Models
{
    public class UserAccount : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CPF { get; set; }
    }
}
