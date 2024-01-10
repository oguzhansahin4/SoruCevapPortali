using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace soruCevapPortali.Models
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Sorular> Questions { get; set; }
        public DbSet<Cevaplar> Answers { get; set; }
        public DbSet<AppUser> User { get; set; }
        public object Sorular { get; internal set; }
    }
}