using Microsoft.EntityFrameworkCore;
using PublisherDomain;
namespace PublisherData
{
    public class PubContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=PublisherDb;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
