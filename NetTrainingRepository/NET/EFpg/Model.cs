namespace EFpg
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("ModelPg")
        {
        }

        public virtual DbSet<Analytic> Analytic { get; set; }
        public virtual DbSet<ClassAnalytic> ClassAnalytic { get; set; }
        public virtual DbSet<Cathedra> Cathedra { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<ClassTeaching> ClassTeaching { get; set; }
        public virtual DbSet<DirProfession> DirProfession { get; set; }
        public virtual DbSet<DirSpecialization> DirSpecialization { get; set; }
        public virtual DbSet<RefSpecialtyProfession> RefSpecialtyProfession { get; set; }
        public virtual DbSet<SetTotal> SetTotal { get; set; }
        public virtual DbSet<Specialty> Specialty { get; set; }
        public virtual DbSet<Univer> Univer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassAnalytic>()
                .HasMany(e => e.Analytic)
                .WithOptional(e => e.ClassAnalytic)
                .HasForeignKey(e => e.ClassId);

            modelBuilder.Entity<DirProfession>()
                .HasMany(e => e.RefSpecialtyProfession)
                .WithOptional(e => e.DirProfession)
                .HasForeignKey(e => e.ProfessionId);

            modelBuilder.Entity<DirSpecialization>()
                .HasMany(e => e.Cathedra)
                .WithOptional(e => e.DirSpecialization)
                .HasForeignKey(e => e.SpecializationId);

            modelBuilder.Entity<DirSpecialization>()
                .HasMany(e => e.DirProfession)
                .WithOptional(e => e.DirSpecialization)
                .HasForeignKey(e => e.SpecializationId);
        }
    }
}
