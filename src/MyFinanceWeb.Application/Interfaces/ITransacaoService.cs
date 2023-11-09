using MyFinanceWeb.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinanceWeb.Application.Interfaces;

public interface ITransacaoService
{
    Task<IEnumerable<TransacaoDTO>> FindAll();
    Task<TransacaoDTO> FindById(int id);
    Task<TransacaoDTO> Create(TransacaoDTO transacao);
    Task<TransacaoDTO> Delete(int id);
    Task<TransacaoDTO> Update(TransacaoDTO transacao);
}

