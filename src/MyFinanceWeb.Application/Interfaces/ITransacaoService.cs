using MyFinanceWeb.Application.DTOs.TransacaoDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinanceWeb.Application.Interfaces;

public interface ITransacaoService
{
    Task<IEnumerable<TransacaoReadDTO>> FindAll();
    Task<TransacaoReadDTO> FindById(int id);
    Task<TransacaoReadDTO> Create(TransacaoCreateDTO transacaoCreateDTO);
    Task<TransacaoReadDTO> Delete(int id);
    Task<TransacaoReadDTO> Update(TransacaoUpdateDTO transacaoUpdateDTO);
}

