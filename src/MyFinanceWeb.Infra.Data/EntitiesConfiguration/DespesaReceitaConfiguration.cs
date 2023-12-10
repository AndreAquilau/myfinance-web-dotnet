using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinanceWeb.Domain.Entities;
using MyFinanceWeb.Domain.ObjectValue;

namespace MyFinanceWeb.Infrastructure.Data.EntitiesConfiguration;

public class DespesaReceitaConfiguration : IEntityTypeConfiguration<DespesaReceita>
{
    public void Configure(EntityTypeBuilder<DespesaReceita> builder)
    {
        builder.HasNoKey();

        builder.Property(p => p.Despesa).HasPrecision(18, 2);

        builder.Property(p => p.Receita).HasPrecision(18, 2);

    }
}

