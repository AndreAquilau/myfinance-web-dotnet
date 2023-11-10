namespace MyFinanceWeb.Domain.Entities;

public class PlanoConta
{
    public PlanoConta()
    {
        Transacoes = new List<Transacao>();
    }

    public int Id { get; set; }

    public string Descricao { get; set; } = string.Empty;

    public char Tipo { get; set;}

    public IEnumerable<Transacao> Transacoes { get; set; }
}

