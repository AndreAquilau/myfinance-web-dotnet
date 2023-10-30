namespace MyFinanceWeb.Domain.Models;

public class Transacao
{
    public Transacao() { }

    public int Id { get; set; }

    public string Historico { get; set; } = string.Empty;

    public char Tipo { get; set; }

    public decimal Valor { get; set; }

    public DateTime Data { get; set; }

    public int PlanoContaId { get; set; }

    public IEnumerable<PlanoConta> PlanoContas { get; set; }

}




