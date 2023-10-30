using MyFinanceWeb.Domain.Models;
using MyFinanceWeb.Infrastructure.Data.Context;

namespace MyFinanceWeb.Services;

public class PlanoContaService : IPlanoContaService
{
    private MyFinanceDbContext _context;

    public PlanoContaService(MyFinanceDbContext context)
    {
        _context = context;
    }

    public IEnumerable<PlanoConta> ListarPlanoContas()
    {
        return this._context.PlanoConta;
    }
}

