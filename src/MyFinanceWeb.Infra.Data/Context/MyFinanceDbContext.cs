using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyFinanceWeb.Domain.Entities;
using MyFinanceWeb.Domain.ObjectValue;

namespace MyFinanceWeb.Infra.Data.Context;

public class MyFinanceDbContext : DbContext
{

    public DbSet<PlanoConta> PlanoConta { get; set; }
    public DbSet<Transacao> Transacao { get; set; }

    public MyFinanceDbContext(DbContextOptions<MyFinanceDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyFinanceDbContext).Assembly);

    }


}
