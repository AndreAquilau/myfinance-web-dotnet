using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinanceWeb.Domain.Models;

namespace MyFinanceWeb.Infrastructure.Data.EntitiesConfiguration;

public class PlanoContaConfiguration : IEntityTypeConfiguration<PlanoConta>
{
    public void Configure(EntityTypeBuilder<PlanoConta> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Descricao).HasMaxLength(50).IsRequired();

        builder.Property(p => p.Tipo).HasMaxLength(1).IsRequired();

        List<PlanoConta> defaultValues = new List<PlanoConta>();

        defaultValues.Add(new PlanoConta(1, "Material Escolar"));
        defaultValues.Add(new PlanoConta(2, "Eletrônicos"));
        defaultValues.Add(new PlanoConta(3, "Acessórios"));

    }
}

