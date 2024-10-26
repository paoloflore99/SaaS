using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace SaaS.Models
{
    public class SaasDbContext : IdentityDbContext<IdentityUser>
    {
        public Prova? prova { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=SaasDb;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}
