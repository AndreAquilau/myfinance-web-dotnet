using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyFinanceWeb.Domain.Entities;

namespace MyFinanceWeb.Infra.Data.Context;

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

}
