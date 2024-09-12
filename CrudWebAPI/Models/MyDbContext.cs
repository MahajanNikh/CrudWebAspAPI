using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrudWebAPI.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)=> optionsBuilder.UseSqlServer();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Table__3214EC07B988F20D");

            entity.ToTable("Student");

            entity.Property(e => e.FatherName)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.StudentGender)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.StudentName)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
