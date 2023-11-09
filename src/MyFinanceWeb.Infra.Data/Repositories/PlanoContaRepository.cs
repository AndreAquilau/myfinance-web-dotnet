using MyFinanceWeb.Domain.Entities;
using MyFinanceWeb.Domain.Repositories;

namespace MyFinanceWeb.Infra.Data.Repositories;

public class PlanoContaRepository : IPlanoContaRepository
{
    public Task<PlanoConta> Create(PlanoConta transacao)
    {
        throw new NotImplementedException();
    }

    public Task<PlanoConta> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PlanoConta>> FindAll()
    {
        throw new NotImplementedException();
    }

    public Task<PlanoConta> FindById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PlanoConta> Update(PlanoConta transacao)
    {
        throw new NotImplementedException();
    }
}

