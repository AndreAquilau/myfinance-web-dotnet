using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyFinanceWeb.Domain.Entities;
using MyFinanceWeb.Domain.ObjectValue;
using MyFinanceWeb.Domain.Repositories;
using MyFinanceWeb.Infra.Data.Context;
using MyFinanceWeb.Infra.Data.Validate;
using System;
using System.Text.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MyFinanceWeb.Infra.Data.Repositories
;
public class UtilRepository : IUtilRepository
{
    private MyFinanceDbContext _context;

    public UtilRepository(MyFinanceDbContext context)
    {
        _context = context;
    }

    public DespesaReceita DespesaReceita(DateOnly dataInit, DateOnly dataEnd)
    {


            var despesa = _context.Transacao
                .Join(_context.PlanoConta,
                    transacao => transacao.PlanoContaId,
                    planoConta => planoConta.Id,
                    (transacao, planoConta) => new { Transacao = transacao, PlanoConta = planoConta })
                .Where(x => x.Transacao.Data >= new DateTime(2022, 01, 01) && x.Transacao.Data <= new DateTime(2023, 12, 31) && x.PlanoConta.Tipo == 'D')
                .Sum(x => x.Transacao.Valor);

            var receita = _context.Transacao
                .Join(_context.PlanoConta,
                    transacao => transacao.PlanoContaId,
                    planoConta => planoConta.Id,
                    (transacao, planoConta) => new { Transacao = transacao, PlanoConta = planoConta })
                .Where(x => x.Transacao.Data >= new DateTime(2022, 01, 01) && x.Transacao.Data <= new DateTime(2023, 12, 31) && x.PlanoConta.Tipo == 'R')
                .Sum(x => x.Transacao.Valor);
        Console.WriteLine(receita);
        Console.WriteLine(despesa);

        return new DespesaReceita() { Despesa = despesa, Receita = receita };

    }

}






public class QueryResult
{
    public decimal Dispesa { get; set; }
    public decimal Receita { get; set; }
}