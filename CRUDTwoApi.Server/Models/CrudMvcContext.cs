using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUDTwoApi.Server.Models;

public partial class CrudMvcContext : DbContext
{
    public CrudMvcContext()
    {
    }

    public CrudMvcContext(DbContextOptions<CrudMvcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Career> Careers { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Career>(entity =>
        {
            entity.HasKey(e => e.CareerId).HasName("PK__Career__A4D2D7F7BC15EEA4");

            entity.ToTable("Career");

            entity.Property(e => e.CareerName)
                .HasMaxLength(35)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52B99B03DFF78");

            entity.ToTable("Student");

            entity.Property(e => e.RegisterDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.StudentAdmissionDate).HasColumnType("date");
            entity.Property(e => e.StudentFirstName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.StudentLastName)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.StudentCareer).WithMany(p => p.Students)
                .HasForeignKey(d => d.StudentCareerId)
                .HasConstraintName("FK__Student__Student__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
