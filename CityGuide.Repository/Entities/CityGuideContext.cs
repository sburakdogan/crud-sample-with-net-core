using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CityGuide.Repository.Entities
{
    public partial class CityGuideContext : DbContext
    {
        public CityGuideContext()
        {
        }

        public CityGuideContext(DbContextOptions<CityGuideContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Photos> Photos { get; set; }
        public virtual DbSet<Towns> Towns { get; set; }
        public virtual DbSet<UserCities> UserCities { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=cityguideserver.database.windows.net;User Id=burak;Password=YesNow123!;Database=CityGuide");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Photos>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.PublicId)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Url).IsRequired();

                entity.HasOne(d => d.UserCity)
                    .WithMany(p => p.Photos)
                    .HasForeignKey(d => d.UserCityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Photos_UserCities");
            });

            modelBuilder.Entity<Towns>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Towns)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Towns_Cities");
            });

            modelBuilder.Entity<UserCities>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.UserCities)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserCities_Cities");

                entity.HasOne(d => d.Town)
                    .WithMany(p => p.UserCities)
                    .HasForeignKey(d => d.TownId)
                    .HasConstraintName("FK_UserCities_Towns");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCities)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserCities_Users");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.MailAddress)
                    .HasName("UQ__Users__F58A94FC8C154CD8")
                    .IsUnique();

                entity.Property(e => e.Avatar).HasMaxLength(200);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.MailAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Salt).IsRequired();

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });
        }
    }
}
