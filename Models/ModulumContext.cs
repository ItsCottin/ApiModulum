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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
