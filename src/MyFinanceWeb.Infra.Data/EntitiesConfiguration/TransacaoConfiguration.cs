using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinanceWeb.Domain.Entities;

namespace MyFinanceWeb.Infrastructure.Data.EntitiesConfiguration;

public class TransacaoConfiguration : IEntityTypeConfiguration<Transacao>
{
    public void Configure(EntityTypeBuilder<Transacao> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Historico).HasMaxLength(256).IsRequired();

        builder.Property(p => p.Valor).HasPrecision(18, 2).IsRequired();

        builder.Property(p => p.PlanoContaId);

        builder.HasOne(p => p.PlanoConta).WithMany(p => p.Transacoes).HasForeignKey(p => p.PlanoContaId);

        List<Transacao> defaultValues = new List<Transacao>()
        {
            new Transacao()
            {
                Id = 100,
                Historico = "Gasolina Viagem",
                Data = DateTime.Parse("2022-12-20 14:00:00"),
                PlanoContaId = 1,
                Valor = 289.00M
            },
            new Transacao()
            {
                Id = 200,
                Historico = "Almoço Família",
                Data = DateTime.Parse("2022-12-24 13:30:00"),
                PlanoContaId = 3,
                Valor = 289.00M
            },
            new Transacao()
            {
                Id = 300,
                Historico = "Salário",
                Data = DateTime.Parse("2023-01-05 00:00:00"),
                PlanoContaId = 6,
                Valor = 289.00M
            },
            new Transacao()
            {
                Id = 400,
                Historico = "IPVA Blazer",
                Data = DateTime.Parse("2023-01-10 13:30:00"),
                PlanoContaId = 5,
                Valor = 289.00M
            }
        };

        builder.HasData(defaultValues);
    }
}

