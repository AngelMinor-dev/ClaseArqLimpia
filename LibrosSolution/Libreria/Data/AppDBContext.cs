using Libreria.Business.Entities;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(){}

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }


        public DbSet<Book> Books { get; set; }

        public DbSet<Autor> Autors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Book>()
                .Property(t => t.Id).ValueGeneratedOnAdd();

            modelbuilder.Entity<Autor>()
               .Property(t => t.Id).ValueGeneratedOnAdd();

            modelbuilder.Entity<Autor>()
                .HasMany(t => t.Books)
                .WithOne(t=>t.Autor)
                .HasForeignKey(t => t.AutorId);


            base.OnModelCreating(modelbuilder);
        }

    }

}
