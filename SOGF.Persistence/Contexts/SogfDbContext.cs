using Microsoft.EntityFrameworkCore;
using SOGF.Domain.Model;

namespace Solution.Persistence.Contexts;

public class SogfDbContext : DbContext
{
    public SogfDbContext(DbContextOptions<SogfDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    public DbSet<Nave> Naves { get; set; }
    public DbSet<Tripulante> Tripulantes { get; set; }
    public DbSet<RelatorioCombate> RelatorioCombates { get; set; }
    public DbSet<Missao> Missoes { get; set; }
}