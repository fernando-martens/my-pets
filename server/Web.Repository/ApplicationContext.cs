using Microsoft.EntityFrameworkCore;
using Web.Models.Tables;
using Web.Repository.Mappings;

namespace Web.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<PetsTable> Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PetsTableMapping());

            base.OnModelCreating(modelBuilder);
        }


    }
}
