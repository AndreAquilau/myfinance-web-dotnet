using MyFinanceWeb.Domain.Entities;
using MyFinanceWeb.Domain.Repositories; 

namespace MyFinanceWeb.Infra.Data.Repositories;


public class PlanoContaRepository : IPlanoContaRepository
{
    readonly List<PlanoConta> _lst = new List<PlanoConta>();

    public async Task<PlanoConta> Create(PlanoConta planoConta)
    {
        _lst.Add(planoConta);
        planoConta.Id = _lst.Count;
        await Task.Delay(1);
        return planoConta;
    }

    public async Task<PlanoConta> Delete(int id)
    {
        var planoConta = _lst.FirstOrDefault(p => p.Id == id);
        if (planoConta != null)
        {
            _lst.Remove(planoConta);
        }
        await Task.Delay(1);
        return planoConta;
    }

    public async Task<IEnumerable<PlanoConta>> FindAll()
    {
        await Task.Delay(1);
        return _lst;
    }

    public async Task<PlanoConta> FindById(int id)
    {
        var planoConta = _lst.FirstOrDefault(p => p.Id == id);
        await Task.Delay(1);
        return planoConta;
    }

    public async Task<PlanoConta> Update(PlanoConta planoConta)
    {
        var result = _lst.FirstOrDefault(p => p.Id == planoConta.Id);
        if (result != null)
        {
            result.Descricao = planoConta.Descricao;
            result.Tipo = planoConta.Tipo;
        }
        await Task.Delay(1);
        return result;
    }
}

