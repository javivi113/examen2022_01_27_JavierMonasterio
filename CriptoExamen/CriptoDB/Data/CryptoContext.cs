#define SQL_NO
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cripto.Models;

public class CryptoContext1 : DbContext
{
    public static string connString { get; private set; } 
#if SQL //SQLServer
     = $"Server=localhost;Database=CryptoDB;User Id=sa;Password=Pa88word;MultipleActiveResultSets=true";
#else //Windows
     = $"Server=(localdb)\\mssqllocaldb;Database=CrytoDB;Trusted_Connection=True;MultipleActiveResultSets=true";
#endif
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(connString);

    // public CryptoContext1(DbContextOptions<CryptoContext1> options) : base(options) { }
    // public CryptoContext1() : base() { }
    
    public DbSet<Cripto.Models.Moneda> Moneda { get; set; }

    public DbSet<Cripto.Models.Cartera> Cartera { get; set; }

    public DbSet<Cripto.Models.Contrato> Contrato { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contrato>().HasIndex(m => new
        {
            m.CarteraId,
            m.MonedaId
        }).IsUnique();
    }
}
