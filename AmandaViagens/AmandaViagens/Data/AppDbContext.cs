using Microsoft.EntityFrameworkCore;
using AmandaViagens.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AmandaViagens.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Cruzeiro> Cruzeiros { get; set; }
    public DbSet<Ingresso> Ingressos { get; set; }
    public DbSet<PontoTuristico> PontoTuristicos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        AppDbSeed seed = new(builder);
    }

}

