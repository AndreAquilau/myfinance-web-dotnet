using Microsoft.EntityFrameworkCore;
using MyFinanceWeb.Domain.Entities;
using MyFinanceWeb.Domain.Repositories;
using MyFinanceWeb.Infra.Data.Context;
using MyFinanceWeb.Infra.Data.Validate;

namespace MyFinanceWeb.Infra.Data.Repositories
;
public class TransacaoRepository : ITransacaoRepository
{
    private MyFinanceDbContext _context;

    public TransacaoRepository(MyFinanceDbContext context)
    {
        _context = context;
    }

    public async Task<Transacao> Create(Transacao transacao)
    {

        await _context.Transacao.AddAsync(transacao);

        await _context.SaveChangesAsync();

        return transacao;

    }

    public async Task<Transacao> Delete(int id)
    {
        var transacao = await _context.Transacao.FirstOrDefaultAsync(x => x.Id == id);

        //Valida se o plano de conta é is null
        RepositoryExceptionValitation.When(transacao is null, "Transacao não encontrado!");

        //Plano Contas não é nulo!
        var dataTransacao = transacao!;

        _context.Transacao.Remove(dataTransacao);

        await _context.SaveChangesAsync();

        return dataTransacao;
    }

    public async Task<IEnumerable<Transacao>> FindAll()
    {
        var transacoes = await _context.Transacao.ToArrayAsync();

        return transacoes;
    }

    public async Task<Transacao> FindById(int id)
    {
        var transacao = await _context.Transacao.FirstOrDefaultAsync(x => x.Id == id);

        //Valida se o plano de conta é is null
        RepositoryExceptionValitation.When(transacao is null, "Transacao não encontrado!");

        //Plano Contas não é nulo!
        var dataTransacao = transacao!;

        return dataTransacao;
    }

    public async Task<Transacao> Update(Transacao transacao)
    {
        var transacaoContaUpdate = await _context.Transacao.FirstOrDefaultAsync(x => x.Id == transacao.Id);

        //Valida se o plano de conta é is null
        RepositoryExceptionValitation.When(transacaoContaUpdate is null, "Transacao não encontrado!");

        //Plano Contas não é nulo!
        var dataTransacao = transacao!;

        _context.Update(dataTransacao);

        await _context.SaveChangesAsync();

        return dataTransacao;
    }
}

