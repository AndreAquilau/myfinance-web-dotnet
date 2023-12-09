using MyFinanceWeb.Domain.Entities;
using MyFinanceWeb.Domain.Repositories;

namespace MyFinanceWeb.Infra.Data.Repositories;

public class TransacaoRepository : ITransacaoRepository
{
    readonly List<Transacao> _lst = new List<Transacao>();

    public async Task<Transacao> Create(Transacao transacao)
    {
        _lst.Add(transacao);
        transacao.Id = _lst.Count;
        await Task.Delay(1);
        return transacao;
    }

    public async Task<Transacao> Delete(int id)
    {
        var transacao = _lst.FirstOrDefault(p => p.Id == id);
        if (transacao != null)
        {
            _lst.Remove(transacao);
        }
        await Task.Delay(1);
        return transacao;
    }

    public async Task<IEnumerable<Transacao>> FindAll()
    {
        await Task.Delay(1);
        return _lst;
    }

    public async Task<Transacao> FindById(int id)
    {
        var transacao = _lst.FirstOrDefault(p => p.Id == id);
        await Task.Delay(1);
        return transacao;
    }

    public async Task<Transacao> Update(Transacao transacao)
    {
        var result = _lst.FirstOrDefault(p => p.Id == transacao.Id);
        if (result != null)
        {
            //result.Descricao = transacao.Descricao;
            //result.Tipo = transacao.Tipo;
        }
        await Task.Delay(1);
        return result;
    }
}

