using ControleFinanceiro.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Data.Context;

public  class ControleFinanceiroContext:DbContext
{
    public ControleFinanceiroContext(DbContextOptions<ControleFinanceiroContext> options) : base(options)
    {

    }

    public DbSet<Expense> Expense { get; set; }
    public DbSet<Parcel> Parcel { get; set; }
    public DbSet<Category> Category { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Expense>()
            .ToTable("Expense")
            .Property(x=>x.Value).HasColumnType("DECIMAL(12,2)");
        modelBuilder.Entity<Parcel>()
            .ToTable("Parcel")
            .Property(x => x.Value).HasColumnType("DECIMAL(12,2)");
        modelBuilder.Entity<Category>().ToTable("Category");
    }
}
