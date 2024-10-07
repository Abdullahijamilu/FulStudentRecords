using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FulStudentRecords.Models;

public partial class StudentRecordsContext : DbContext
{
    public StudentRecordsContext()
    {
    }

    public StudentRecordsContext(DbContextOptions<StudentRecordsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Record> Records { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-BEG6RIV;Database=StudentRecords;User Id=Abdullahi Onimisi;Password=Abdul131; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Record>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Records__3214EC0758F89E52");

            entity.Property(e => e.Biology)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("biology");
            entity.Property(e => e.Chemistry)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("chemistry");
            entity.Property(e => e.English)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("english");
            entity.Property(e => e.Grade)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Maths)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("maths");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Physics)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("physics");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
