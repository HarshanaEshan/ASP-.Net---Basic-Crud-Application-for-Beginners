using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Student_Registration_Crud_Application.Models;

public partial class UniversityContext : DbContext
{
    public UniversityContext()
    {
    }

    public UniversityContext(DbContextOptions<UniversityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<StudentsTable> StudentsTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-3LCAHBE\\SQLEXPRESS;Database=University;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentsTable>(entity =>
        {
            entity.HasKey(e => e.StudentId);

            entity.ToTable("Students_Table");

            entity.Property(e => e.StudentId)
                .ValueGeneratedNever()
                .HasColumnName("Student_ID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("First_Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Last_Name");
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Username)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
