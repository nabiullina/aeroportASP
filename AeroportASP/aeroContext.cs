using System;
using System.Collections.Generic;
using AeroportASP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AeroportASP
{
    public partial class aeroContext : DbContext
    {
        public aeroContext()
        {
        }

        public aeroContext(DbContextOptions<aeroContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<PassInTrip> PassInTrips { get; set; } = null!;
        public virtual DbSet<Passenger> Passengers { get; set; } = null!;
        public virtual DbSet<Trip> Trips { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ZENBOOK;Database=aero;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.IdComp)
                    .HasName("PK2");

                entity.ToTable("Company");

                entity.Property(e => e.IdComp)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_comp");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .IsFixedLength();
            });

            modelBuilder.Entity<PassInTrip>(entity =>
            {
                entity.HasKey(e => new { e.TripNo, e.Date, e.IdPsg })
                    .HasName("PK_pt");

                entity.ToTable("Pass_in_trip");

                entity.Property(e => e.TripNo).HasColumnName("trip_no");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.IdPsg).HasColumnName("ID_psg");

                entity.Property(e => e.Place)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("place")
                    .IsFixedLength();

                entity.HasOne(d => d.IdPsgNavigation)
                    .WithMany(p => p.PassInTrips)
                    .HasForeignKey(d => d.IdPsg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pass_in_trip_Passenger");

                entity.HasOne(d => d.TripNoNavigation)
                    .WithMany(p => p.PassInTrips)
                    .HasForeignKey(d => d.TripNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pass_in_trip_Trip");
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.HasKey(e => e.IdPsg)
                    .HasName("PK_psg");

                entity.ToTable("Passenger");

                entity.Property(e => e.IdPsg)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_psg");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.HasKey(e => e.TripNo)
                    .HasName("PK_t");

                entity.ToTable("Trip");

                entity.Property(e => e.TripNo)
                    .ValueGeneratedNever()
                    .HasColumnName("trip_no");

                entity.Property(e => e.IdComp).HasColumnName("ID_comp");

                entity.Property(e => e.Plane)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("plane")
                    .IsFixedLength();

                entity.Property(e => e.TimeIn)
                    .HasColumnType("datetime")
                    .HasColumnName("time_in");

                entity.Property(e => e.TimeOut)
                    .HasColumnType("datetime")
                    .HasColumnName("time_out");

                entity.Property(e => e.TownFrom)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("town_from")
                    .IsFixedLength();

                entity.Property(e => e.TownTo)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("town_to")
                    .IsFixedLength();

                entity.HasOne(d => d.IdCompNavigation)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.IdComp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Trip_Company");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
