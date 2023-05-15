using Microsoft.EntityFrameworkCore;

namespace doweb
{
    public class ApplicationContexts : DbContext
    {
        public ApplicationContexts(string connectionString)
        {
            this.connectionString = connectionString;
            Database.EnsureCreated();
        }
        public DbSet<Document> Documents { get; set; } = null!;
        public string connectionString;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString);
        }
    }
}
