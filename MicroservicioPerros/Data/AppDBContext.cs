using MicroservicioPerros.Business.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroservicioPerros.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(){}


        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }

        /*Registrar Entidades*/
        public DbSet<Dog> Dogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>()
                .Property(d => d.Id)
                .ValueGeneratedOnAdd();
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
