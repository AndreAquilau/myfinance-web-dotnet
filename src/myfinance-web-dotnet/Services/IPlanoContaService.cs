using MyFinanceWeb.Domain.Models;

namespace MyFinanceWeb.Services;

public interface IPlanoContaService
{
    IEnumerable<PlanoConta> ListarPlanoContas();
}

