using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyFinanceWeb.Domain.Models;
using System.Configuration;

namespace MyFinanceWeb.Infrastructure.Data.Context;

public class MyFinanceDbContext : DbContext
{
    private IConfiguration _conf;

    public DbSet<PlanoConta> PlanoConta { get; set; }

    public DbSet<Transacao> Transacao { get; set; }


    public MyFinanceDbContext(DbContextOptions<MyFinanceDbContext> options, IConfiguration conf) : base(options) { 
        _conf = conf;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _conf.GetConnectionString("DefaultConnection");

        optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly(typeof(MyFinanceDbContext).Assembly.FullName));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyFinanceDbContext).Assembly);

    }
}
