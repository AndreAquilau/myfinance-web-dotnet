using MyFinanceWeb.Application.DTOs.PlanoContaDTOs;
using MyFinanceWeb.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinanceWeb.Application.Services;

public class PlanoContaService : IPlanoContaService
{
    public Task<PlanoContaReadDTO> Create(PlanoContaCreateDTO planoContaCreateDTO)
    {
        throw new NotImplementedException();
    }

    public Task<PlanoContaReadDTO> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PlanoContaReadDTO>> FindAll()
    {
        throw new NotImplementedException();
    }

    public Task<PlanoContaReadDTO> FindById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PlanoContaReadDTO> Update(PlanoContaUpdateDTO planoContaUpdateDTO)
    {
        throw new NotImplementedException();
    }
}

