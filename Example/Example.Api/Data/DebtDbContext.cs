using Microsoft.EntityFrameworkCore;

namespace Example.Api.DataModels
{
    public sealed class DebtDbContext : DbContext
    {
        public DebtDbContext()
        {
        }

        public DebtDbContext(DbContextOptions<DebtDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Debtor> Debtors { get; set; }

        public DbSet<File> Files { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test");
        //}

    }
}
