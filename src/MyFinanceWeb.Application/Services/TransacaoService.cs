using MyFinanceWeb.Application.DTOs.TransacaoDTOs;
using MyFinanceWeb.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinanceWeb.Application.Services;

public class TransacaoService : ITransacaoService
{
    public Task<TransacaoReadDTO> Create(TransacaoCreateDTO transacaoCreateDTO)
    {
        throw new NotImplementedException();
    }

    public Task<TransacaoReadDTO> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TransacaoReadDTO>> FindAll()
    {
        throw new NotImplementedException();
    }

    public Task<TransacaoReadDTO> FindById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<TransacaoReadDTO> Update(TransacaoUpdateDTO transacaoUpdateDTO)
    {
        throw new NotImplementedException();
    }
}

