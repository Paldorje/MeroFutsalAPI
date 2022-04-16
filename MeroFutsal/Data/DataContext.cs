using MeroFutsal.Models;

namespace MeroFutsal.Data
{
        public partial class DataContext : DbContext
        {


        public DataContext(DbContextOptions<DataContext> options)
                : base(options)
            { }

            public DbSet<User> Users { get; set; }
            public DbSet<Futsal> Futsals { get; set; }
            public  DbSet<Photo> Photos { get; set; }
            public  DbSet<Booking> Bookings { get; set; }
            public  DbSet<Ground> Grounds { get; set; }
            public DbSet<Owner> Owners { get; set; }

            public DbSet<UserBooking> UserBooking { get; set; }

            public DbSet<GroundBooking> GroundBooking { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserBooking>()
                .HasKey(ub => new { ub.UserEmail, ub.BookingId });

            modelBuilder.Entity<GroundBooking>()
                .HasKey(gb => new { gb.GroundId, gb.BookingId });


            //modelBuilder.Entity<Owner>()
            //    .HasOne<Futsal>(f => f.Futsals)
            //    .WithOne(o => o.Owners)
            //    .HasForeignKey<Futsal>(o => o.OwnerEmail);




            //modelBuilder.Entity<Futsal>()
            //.HasOne<Ground>(g => g.Grounds)
            //.WithMany(f => f.Futsals)
            //.HasForeignKey(g => g.Futsalid);
        }

    }
    }
