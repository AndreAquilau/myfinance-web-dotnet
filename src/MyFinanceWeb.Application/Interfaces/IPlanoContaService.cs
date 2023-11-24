using MyFinanceWeb.Application.DTOs.PlanoContaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinanceWeb.Application.Interfaces;

public interface IPlanoContaService
{
    Task<IEnumerable<PlanoContaReadDTO>> FindAll();
    Task<PlanoContaReadDTO> FindById(int id);
    Task<PlanoContaReadDTO> Create(PlanoContaCreateDTO planoContaCreateDTO);
    Task<PlanoContaReadDTO> Delete(int id);
    Task<PlanoContaReadDTO> Update(PlanoContaUpdateDTO planoContaUpdateDTO);
}

