namespace MyFinanceWeb.Domain.Models;

public class PlanoConta
{
    public int Id { get; set; }

    public string Descricao { get; set; } = string.Empty;

    public char Tipo { get; set;}

    public Transacao Transacao { get; set; }
}

