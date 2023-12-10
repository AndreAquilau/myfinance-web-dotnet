using MyFinanceWeb.Domain.Entities;
using MyFinanceWeb.Domain.ObjectValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinanceWeb.Domain.Repositories;

public interface IUtilRepository
{
    Task<DespesaReceita> DespesaReceita(DateOnly dataInit, DateOnly dataEnd);
}

