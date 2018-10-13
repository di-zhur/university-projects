using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Mds.DataAccess.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mds.DataAccess
{
  public partial class ModelDbContext : DbContext
  {
    public ModelDbContext()
    {
    }

    public ModelDbContext(DbContextOptions<ModelDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Model> Model { get; set; }
    public virtual DbSet<ModelVersion> ModelVersion { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        optionsBuilder.UseSqlServer("Server=DESKTOP-693MBN3\\SQLEXPRESS;Database=ModelDB;Trusted_Connection=True;");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Model>(entity =>
      {
        entity.Property(e => e.Id).ValueGeneratedNever();

        entity.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(100);
      });

      modelBuilder.Entity<ModelVersion>(entity =>
      {
        entity.Property(e => e.Id).ValueGeneratedNever();

        entity.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(100);

        entity.HasOne(d => d.Model)
                  .WithMany(p => p.ModelVersion)
                  .HasForeignKey(d => d.ModelId)
                  .HasConstraintName("FK__ModelVers__Model__25869641");
      });
    }

    
   
  }
}
