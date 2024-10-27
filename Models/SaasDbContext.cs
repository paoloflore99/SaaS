using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace SaaS.Models
{
    public class SaasDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Prova>? Prove { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=SaasDb;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
