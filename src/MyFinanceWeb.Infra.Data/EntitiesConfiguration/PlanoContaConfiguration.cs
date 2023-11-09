using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinanceWeb.Domain.Entities;

namespace MyFinanceWeb.Infrastructure.Data.EntitiesConfiguration;

public class PlanoContaConfiguration : IEntityTypeConfiguration<PlanoConta>
{
    public void Configure(EntityTypeBuilder<PlanoConta> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Descricao).HasMaxLength(50).IsRequired();

        builder.Property(p => p.Tipo).HasMaxLength(1).IsRequired();

        IEnumerable<PlanoConta> defaultValues = new List<PlanoConta>()
        {
            new PlanoConta()
            {
                Id = 1,
                Descricao = "Combustível",
                Tipo = 'D'
            },
            new PlanoConta()
            {
                Id = 2,
                Descricao = "Supermercado",
                Tipo = 'D'
            },
            new PlanoConta()
            {
                Id = 3,
                Descricao = "Almoço",
                Tipo = 'D'
            },
            new PlanoConta()
            {
                Id = 4,
                Descricao = "IPTU",
                Tipo = 'D'
            },
            new PlanoConta()
            {
                Id = 5,
                Descricao = "IPVA",
                Tipo = 'D'
            },
            new PlanoConta()
            {
                Id = 6,
                Descricao = "Salário",
                Tipo = 'R'
            },
            new PlanoConta()
            {
                Id = 7,
                Descricao = "Crédito de Juros",
                Tipo = 'R'
            },
            new PlanoConta()
            {
                Id = 8,
                Descricao = "Apartamento de Aluguel",
                Tipo = 'R'
            },
        };

        builder.HasData(defaultValues);

    }
}

