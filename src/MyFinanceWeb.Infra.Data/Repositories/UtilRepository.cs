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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyFinanceWeb.Infra.Data.Repositories
;
public class UtilRepository : IUtilRepository
{
    private MyFinanceDbContext _context;

    public UtilRepository(MyFinanceDbContext context)
    {
        _context = context;
    }

    public async Task<DespesaReceita> DespesaReceita(DateOnly dataInit, DateOnly dataEnd)
    {
        var pDataInit = new SqlParameter("pDataInit", dataInit.ToString("yyyy-MM-dd"));
        var pDataEnd = new SqlParameter("pDataEnd", dataEnd.ToString("yyyy-MM-dd"));
        var despesaReceita = await _context.Set<DespesaReceita>().FromSqlRaw($@"
            SELECT 
                ISNULL(SUM(IIF(P.Tipo = 'D', Valor, 0.00)), 0.00) AS Despesa, 
                ISNULL(SUM(IIF(P.Tipo = 'R', Valor, 0.00)), 0.00) AS Receita 
            FROM Transacao T
            INNER JOIN PlanoConta P ON T.PlanoContaId = P.Id
            WHERE T.Data BETWEEN @pDataInit AND @pDataEnd;
            ", new object[] { pDataInit, pDataEnd })
            .ToListAsync();

        var data = despesaReceita.FirstOrDefault();

        if (data is null)
        {
            return new DespesaReceita() { Despesa = 0.00M, Receita = 0.00M };

        }
        else
        {
            return data;
        }

    }

}