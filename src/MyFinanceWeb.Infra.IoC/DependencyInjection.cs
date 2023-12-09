using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyFinanceWeb.Application.DTOs;
using MyFinanceWeb.Application.Interfaces;
using MyFinanceWeb.Application.Services;
using MyFinanceWeb.Domain.Entities;
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

        return services;
    }

    // Pode mover para o projeto Application
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IPlanoContaService, PlanoContaService>();

        return services;
    } 

}
