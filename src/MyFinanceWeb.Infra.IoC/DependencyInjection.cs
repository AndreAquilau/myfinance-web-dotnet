using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyFinanceWeb.Application.Interfaces;
using MyFinanceWeb.Application.Services;
using MyFinanceWeb.Domain.Repositories;
using MyFinanceWeb.Infra.Data.Context;
using MyFinanceWeb.Infra.Data.Repositories;

namespace MyFinanceWeb.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<MyFinanceDbContext>(
            options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly(typeof(MyFinanceDbContext).Assembly.FullName))
        );
        services.AddScoped<IPlanoContaRepository, PlanoContaRepository>();
        services.AddScoped<ITransacaoRepository, TransacaoRepository>();
        services.AddScoped<ITransacaoService, TransacaoService>();
        services.AddScoped<IPlanoContaService, PlanoContaService>();

        return services;
    }
}
