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



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<Photo>(entity =>
        //    {
        //        entity.ToTable("photos");

        //        entity.Property(e => e.Photoid).HasColumnName("photoid");

        //        entity.Property(e => e.Groundid).HasColumnName("Groundid");


        //    });

        //    modelBuilder.Entity<Booking>(entity =>
        //    {
        //        entity.HasKey(e => e.Bookingid);

        //        entity.ToTable("Bookings");

        //        entity.Property(e => e.Bookingid).HasColumnName("Bookingid");

        //        entity.Property(e => e.Userid).HasColumnName("Userid");

        //        entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");

        //        entity.Property(e => e.Groundid).HasColumnName("Groundid");

        //        entity.HasOne(d => d.Ground)
        //            .WithMany(p => p.Bookings)
        //            .HasForeignKey(d => d.Groundid)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_Bookings_Grounds");
        //    });

        //    modelBuilder.Entity<Ground>(entity =>
        //    {
        //        entity.ToTable("Grounds");

        //        entity.Property(e => e.Groundid).HasColumnName("Groundid");

        //        entity.Property(e => e.Futsalid).HasColumnName("hotelid");

        //        entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");

        //        entity.Property(e => e.Isreserved).HasColumnName("isreserved");

        //        entity.Property(e => e.Time)
        //            .HasMaxLength(50)
        //            .HasColumnName("time");


        //    });

        //    modelBuilder.Entity<User>(entity =>
        //    {
        //        entity.ToTable("users");

        //        entity.Property(e => e.userid).HasColumnName("userid");

        //        entity.Property(e => e.Address)
        //            .HasMaxLength(50)
        //            .HasColumnName("address");

        //        entity.Property(e => e.Email)
        //            .IsRequired()
        //            .HasMaxLength(50)
        //            .HasColumnName("email");

        //        entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");

        //        entity.Property(e => e.name)
        //            .IsRequired()
        //            .HasMaxLength(50)
        //            .HasColumnName("name");

        //        entity.Property(e => e.Password)
        //            .IsRequired()
        //            .HasMaxLength(50)
        //            .HasColumnName("password");

        //        entity.Property(e => e.Photo).HasColumnName("photo");

        //    });

        //    OnModelCreatingPartial(modelBuilder);
        //}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
    }
