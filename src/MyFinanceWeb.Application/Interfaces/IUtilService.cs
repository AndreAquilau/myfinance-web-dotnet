using MyFinanceWeb.Application.DTOs;
using MyFinanceWeb.Application.DTOs.TransacaoDTOs;
using MyFinanceWeb.Domain.ObjectValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinanceWeb.Application.Interfaces;

public interface IUtilService
{
    DespesaReceitaDTO DespesaReceita(DateOnly dataInit, DateOnly dataEnd);
}

