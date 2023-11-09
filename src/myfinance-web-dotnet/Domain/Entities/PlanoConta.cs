namespace MyFinanceWeb.Domain.Entities;

public class PlanoConta
{
    public int Id { get; set; }

    public string Descricao { get; set; } = string.Empty;

    public char Tipo { get; set;}

    public required Transacao Transacao { get; set; }
}

