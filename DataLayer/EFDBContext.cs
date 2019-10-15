using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataLayer
{
    public class EFDBContext : DbContext
    {
        public DbSet<Book> book { get; set; }
        public DbSet<Author> author { get; set; }
        public DbSet<Reader> reader { get; set; }
        public DbSet<Log> log { get; set; }
        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasOne(b => b.Author).WithMany(a => a.Books).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Log>().HasOne(l => l.Book).WithMany(b => b.Logs).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Log>().HasOne(l => l.Reader).WithMany(r => r.Logs).OnDelete(DeleteBehavior.SetNull);
        }

    }
    public class EFDBContextFactory : IDesignTimeDbContextFactory<EFDBContext>
    {
        public EFDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFDBContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LibraryDb;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("DataLayer"));
            return new EFDBContext(optionsBuilder.Options);
        }
    }
}