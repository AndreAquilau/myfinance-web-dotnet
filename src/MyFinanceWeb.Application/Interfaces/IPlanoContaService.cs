using MyFinanceWeb.Application.DTOs.PlanoContaDTOs;
using MyFinanceWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinanceWeb.Application.Interfaces;

public interface IPlanoContaService
{
    Task<IEnumerable<PlanoContaDTO>> FindAll();
    Task<PlanoContaDTO> FindById(int id);
    Task<PlanoContaDTO> Create(PlanoContaDTO planoContaDTO);
    Task<PlanoContaDTO> Delete(int id);
    Task<PlanoContaDTO> Update(PlanoContaDTO planoContaDTO);
}

