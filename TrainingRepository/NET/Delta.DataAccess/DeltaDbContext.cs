namespace Delta.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataBaseContext : DbContext
    {
        public DataBaseContext()
            : base("name=DataBaseContext")
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<ClassStatistic> ClassStatistic { get; set; }
        public virtual DbSet<Faculty> Faculty { get; set; }
        public virtual DbSet<Profession> Profession { get; set; }
        public virtual DbSet<SetTotal> SetTotal { get; set; }
        public virtual DbSet<Specialization> Specialization { get; set; }
        public virtual DbSet<Specialty> Specialty { get; set; }
        public virtual DbSet<Statistic> Statistic { get; set; }
        public virtual DbSet<University> University { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasMany(e => e.University)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClassStatistic>()
                .HasMany(e => e.Statistic)
                .WithRequired(e => e.ClassStatistic)
                .HasForeignKey(e => e.ClassId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Faculty>()
                .HasMany(e => e.Specialty)
                .WithRequired(e => e.Faculty)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Specialization>()
                .HasMany(e => e.Faculty)
                .WithRequired(e => e.Specialization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Specialization>()
                .HasMany(e => e.Profession)
                .WithRequired(e => e.Specialization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Specialty>()
                .HasMany(e => e.SetTotal)
                .WithRequired(e => e.Specialty)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<University>()
                .HasMany(e => e.Faculty)
                .WithRequired(e => e.University)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<University>()
                .HasMany(e => e.Statistic)
                .WithRequired(e => e.University)
                .WillCascadeOnDelete(false);
        }
    }
}
