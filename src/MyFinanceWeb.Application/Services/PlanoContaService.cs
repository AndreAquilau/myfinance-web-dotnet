using MyFinanceWeb.Application.DTOs;
using MyFinanceWeb.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinanceWeb.Application.Services;

public class PlanoContaService : IPlanoContaService
{
    public Task<PlanoContaDTO> Create(PlanoContaDTO transacao)
    {
        throw new NotImplementedException();
    }

    public Task<PlanoContaDTO> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PlanoContaDTO>> FindAll()
    {
        throw new NotImplementedException();
    }

    public Task<PlanoContaDTO> FindById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PlanoContaDTO> Update(PlanoContaDTO transacao)
    {
        throw new NotImplementedException();
    }
}

