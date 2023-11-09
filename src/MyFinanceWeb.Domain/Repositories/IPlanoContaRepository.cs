using MyFinanceWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinanceWeb.Domain.Repositories;

public interface IPlanoContaRepository
{
    Task<IEnumerable<PlanoConta>> FindAll();
    Task<PlanoConta> FindById(int id);
    Task<PlanoConta> Create(PlanoConta transacao);
    Task<PlanoConta> Delete(int id);
    Task<PlanoConta> Update(PlanoConta transacao);
}

