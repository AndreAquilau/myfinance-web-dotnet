using MyFinanceWeb.Domain.Entities;
using MyFinanceWeb.Domain.Repositories;

namespace MyFinanceWeb.Infra.Data.Repositories
;
public class TransacaoRepository : ITransacaoRepository
{
    public Task<Transacao> Create(Transacao transacao)
    {
        throw new NotImplementedException();
    }

    public Task<Transacao> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Transacao>> FindAll()
    {
        throw new NotImplementedException();
    }

    public Task<Transacao> FindById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Transacao> Update(Transacao transacao)
    {
        throw new NotImplementedException();
    }
}

