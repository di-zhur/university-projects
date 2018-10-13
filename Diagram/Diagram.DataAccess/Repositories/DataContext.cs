using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Diagram.DataAccess.Repositories.Entity;

namespace Diagram.DataAccess.Repositories
{
    public partial class DataContext : DbContext
    {
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<ClassStatistic> ClassStatistic { get; set; }
        public virtual DbSet<Faculty> Faculty { get; set; }
        public virtual DbSet<Profession> Profession { get; set; }
        public virtual DbSet<SetTotal> SetTotal { get; set; }
        public virtual DbSet<Specialization> Specialization { get; set; }
        public virtual DbSet<Specialty> Specialty { get; set; }
        public virtual DbSet<Statistic> Statistic { get; set; }
        public virtual DbSet<University> University { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-693MBN3\SQLEXPRESS;Database=Delta;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<ClassStatistic>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Specialization)
                    .WithMany(p => p.Faculty)
                    .HasForeignKey(d => d.SpecializationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Faculty_Specialization");

                entity.HasOne(d => d.University)
                    .WithMany(p => p.Faculty)
                    .HasForeignKey(d => d.UniversityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Faculty_University");
            });

            modelBuilder.Entity<Profession>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Specialization)
                    .WithMany(p => p.Profession)
                    .HasForeignKey(d => d.SpecializationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Profession_Specialization");
            });

            modelBuilder.Entity<SetTotal>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Year).HasColumnType("date");

                entity.HasOne(d => d.Specialty)
                    .WithMany(p => p.SetTotal)
                    .HasForeignKey(d => d.SpecialtyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SetTotal_Specialty");
            });

            modelBuilder.Entity<Specialization>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Specialty>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Specialty)
                    .HasForeignKey(d => d.FacultyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Specialty_Faculty");
            });

            modelBuilder.Entity<Statistic>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Statistic)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Statistic_ClassStatistic");

                entity.HasOne(d => d.University)
                    .WithMany(p => p.Statistic)
                    .HasForeignKey(d => d.UniversityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Statistic_University");
            });

            modelBuilder.Entity<University>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.University)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_University_City");
            });
        }
    }
}
