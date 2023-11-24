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
    public Task<TransacaoDTO> Create(TransacaoDTO transacao)
    {
        throw new NotImplementedException();
    }

    public Task<TransacaoDTO> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TransacaoDTO>> FindAll()
    {
        throw new NotImplementedException();
    }

    public Task<TransacaoDTO> FindById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<TransacaoDTO> Update(TransacaoDTO transacao)
    {
        throw new NotImplementedException();
    }
}

