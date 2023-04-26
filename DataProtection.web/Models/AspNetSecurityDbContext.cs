using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataProtection.web.Models;

public partial class AspNetSecurityDbContext : DbContext
{
    public AspNetSecurityDbContext()
    {
    }

    public AspNetSecurityDbContext(DbContextOptions<AspNetSecurityDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
