using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ReservacionesRestful.Bussiness.Entities;

namespace ReservacionesRestful.Data
{
    /*Esta clase representa al contexto (conexión a la base de datos)*/
    public class AppDBContext : DbContext
    {
        public AppDBContext()
        {

        }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }


        public DbSet<User> Users { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Reservation> Reservations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<User>()
                .Property(t => t.Id).ValueGeneratedOnAdd();

            modelbuilder.Entity<Room>()
               .Property(t => t.Id).ValueGeneratedOnAdd();

            modelbuilder.Entity<Reservation>()
               .Property(t => t.Id).ValueGeneratedOnAdd();

            modelbuilder.Entity<Room>()
                .HasMany(t => t.Reservations)
                .WithOne(t => t.Room)
                .HasForeignKey(r => r.RoomId);

            base.OnModelCreating(modelbuilder);
        }

    }
}
