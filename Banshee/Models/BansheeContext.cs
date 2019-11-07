using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Banshee.Models
{
    public partial class BansheeContext : DbContext
    {
        public BansheeContext()
        {
        }

        public BansheeContext(DbContextOptions<BansheeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<SalesRepresentative> SalesRepresentative { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Visit> Visit { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=CO-IT004967;Database=Banshee;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.StateId).HasColumnName("state_id");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_city_state");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(50);

                entity.Property(e => e.AvailableCredit).HasColumnName("available_credit");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.CreditLimit).HasColumnName("credit_limit");

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasColumnName("fullname")
                    .HasMaxLength(50);

                entity.Property(e => e.Nit)
                    .IsRequired()
                    .HasColumnName("nit")
                    .HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(20);

                entity.Property(e => e.VisitsPercentage).HasColumnName("visits_percentage");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_client_city");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SalesRepresentative>(entity =>
            {
                entity.ToTable("sales_representative");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("state");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.State)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_state_country");
            });

            modelBuilder.Entity<Visit>(entity =>
            {
                entity.ToTable("visit");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.Net).HasColumnName("net");

                entity.Property(e => e.SalesRepresentativeId).HasColumnName("sales_representative_id");

                entity.Property(e => e.VisitTotal).HasColumnName("visit_total");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Visit)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_visit_client");

                entity.HasOne(d => d.SalesRepresentative)
                    .WithMany(p => p.Visit)
                    .HasForeignKey(d => d.SalesRepresentativeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_visit_sales_representative");
            });
        }
    }
}
