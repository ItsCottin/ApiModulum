using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApiModulum.Models;

public partial class ModulumContext : DbContext
{

    public ModulumContext()
    {
        
    }

    public ModulumContext(DbContextOptions<ModulumContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuario { get; set; } = null!;

    public virtual DbSet<Log> Log { get; set; } = null!;

    public virtual DbSet<RefreshToken> RefreshToken { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(e => e.loginUsu);
            });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
