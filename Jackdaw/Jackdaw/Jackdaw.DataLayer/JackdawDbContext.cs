using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Jackdaw.DataLayer
{
    public partial class JackdawDbContext : DbContext
    {
        public virtual DbSet<DirContest> DirContest { get; set; }
        public virtual DbSet<DirNomination> DirNomination { get; set; }
        public virtual DbSet<Institution> Institution { get; set; }
        public virtual DbSet<Participant> Participant { get; set; }
        public virtual DbSet<RegisteredContest> RegisteredContest { get; set; }
        public virtual DbSet<RegisteredParticipant> RegisteredParticipant { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-693MBN3\SQLEXPRESS;Database=JackdawDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DirContest>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<DirNomination>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Contest)
                    .WithMany(p => p.DirNomination)
                    .HasForeignKey(d => d.ContestId)
                    .HasConstraintName("FK__DirNomina__Conte__38996AB5");
            });

            modelBuilder.Entity<Institution>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Fio)
                    .IsRequired()
                    .HasMaxLength(70);
            });

            modelBuilder.Entity<RegisteredContest>(entity =>
            {
                entity.Property(e => e.СompletionDate).HasColumnType("datetime");

                entity.HasOne(d => d.Nomination)
                    .WithMany(p => p.RegisteredContest)
                    .HasForeignKey(d => d.NominationId)
                    .HasConstraintName("FK__Registere__Nomin__31EC6D26");
            });

            modelBuilder.Entity<RegisteredParticipant>(entity =>
            {
                entity.Property(e => e.NameWork)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Institution)
                    .WithMany(p => p.RegisteredParticipant)
                    .HasForeignKey(d => d.InstitutionId)
                    .HasConstraintName("FK__Registere__Insti__34C8D9D1");

                entity.HasOne(d => d.Participant)
                    .WithMany(p => p.RegisteredParticipant)
                    .HasForeignKey(d => d.ParticipantId)
                    .HasConstraintName("FK__Registere__Parti__33D4B598");

                entity.HasOne(d => d.RegisteredContest)
                    .WithMany(p => p.RegisteredParticipant)
                    .HasForeignKey(d => d.RegisteredContestId)
                    .HasConstraintName("FK__Registere__Regis__32E0915F");
            });
        }
    }
}
