using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinanceWeb.Domain.Models;

namespace MyFinanceWeb.Infrastructure.Data.EntitiesConfiguration;

public class TransacaoConfiguration : IEntityTypeConfiguration<Transacao>
{
    public void Configure(EntityTypeBuilder<Transacao> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Historico).HasMaxLength(256).IsRequired();

        builder.Property(p => p.Tipo).HasMaxLength(5000).IsRequired();

        builder.Property(p => p.Valor).HasPrecision(10, 2).IsRequired();

        builder.Property(p => p.PlanoContaId);


        builder.HasMany(p => p.PlanoContas).WithOne(p => p.Transacao).HasForeignKey(p => p.Id);

        List<Transacao> defaultValues = new List<Transacao>();

        defaultValues.Add(new Transacao(1, "Material Escolar"));
        defaultValues.Add(new Transacao(2, "Eletrônicos"));
        defaultValues.Add(new Transacao(3, "Acessórios"));
    }
}

