using Microsoft.EntityFrameworkCore;
using MyFinanceWeb.Domain.Entities;
using MyFinanceWeb.Domain.Repositories;
using MyFinanceWeb.Infra.Data.Context;
using MyFinanceWeb.Infra.Data.Validate;

namespace MyFinanceWeb.Infra.Data.Repositories;

public class PlanoContaRepository : IPlanoContaRepository
{
    private MyFinanceDbContext _context;

    public PlanoContaRepository(MyFinanceDbContext context)
    {
        _context = context;
    }

    public async Task<PlanoConta> Create(PlanoConta planoConta)
    {

        await _context.PlanoConta.AddAsync(planoConta);

        await _context.SaveChangesAsync();

        return planoConta;

    }

    public async Task<PlanoConta> Delete(int id)
    {
        var planoConta = await _context.PlanoConta.FirstOrDefaultAsync(x => x.Id == id);

        //Valida se o plano de conta é is null
        RepositoryExceptionValitation.When(planoConta is null, "Plano de Contas não encontrado!");

        //Plano Contas não é nulo!
        var dataPlanoConta = planoConta!;

        _context.PlanoConta.Remove(dataPlanoConta);

        await _context.SaveChangesAsync();

        return dataPlanoConta;
    }

    public async Task<IEnumerable<PlanoConta>> FindAll()
    {
        var planoConta = await _context.PlanoConta.ToArrayAsync();

        return planoConta;
    }

    public async Task<PlanoConta> FindById(int id)
    {
        var planoConta = await _context.PlanoConta.FirstOrDefaultAsync(x => x.Id == id);

        //Valida se o plano de conta é is null
        RepositoryExceptionValitation.When(planoConta is null, "Plano de Contas não encontrado!");

        //Plano Contas não é nulo!
        var dataPlanoConta = planoConta!;

        return dataPlanoConta;
    }

    public async Task<PlanoConta> Update(PlanoConta planoConta)
    {
        var planoContaUpdate = await _context.PlanoConta.FirstOrDefaultAsync(x => x.Id == planoConta.Id);

        //Valida se o plano de conta é is null
        RepositoryExceptionValitation.When(planoContaUpdate is null, "Plano de Contas não encontrado!");

        //Plano Contas não é nulo!
        var dataPlanoConta = planoConta!;

        _context.Update(dataPlanoConta);

        await _context.SaveChangesAsync();

        return dataPlanoConta;
    }

}

