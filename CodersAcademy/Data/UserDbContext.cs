using CodersAcademy.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodersAcademy.Data
{
    public class UserDbContext : IdentityDbContext<UserAccount>
    {

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }

        public DbSet<UserAccount> UserAccounts { get; set; }

    }
}
