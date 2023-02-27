using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace prac1.Entities.DataModels;

public partial class Data : DbContext
{
    public Data()
    {
    }

    public Data(DbContextOptions<Data> options)
        : base(options)
    {
    }

    public virtual DbSet<Login> Logins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PCT119\\SQL2017;Database=prac;Persist Security Info=False;User ID=sa;Password=Tatva@123;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False; Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Login>(entity =>
        {
            entity.ToTable("login");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
