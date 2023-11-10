namespace MyFinanceWeb.Domain.Entities;

public class Transacao
{
    public int Id { get; set; }

    public string Historico { get; set; } = string.Empty;

    public decimal Valor { get; set; }

    public DateTime Data { get; set; }

    public int PlanoContaId { get; set; }

    public PlanoConta? PlanoConta { get; set; }

}




