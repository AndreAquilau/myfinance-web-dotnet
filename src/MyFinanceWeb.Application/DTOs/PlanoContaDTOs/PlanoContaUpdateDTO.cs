using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFinanceWeb.Application.DTOs.TransacaoDTOs;

namespace MyFinanceWeb.Application.DTOs.PlanoContaDTOs;

public record PlanoContaUpdateDTO
{
    public int Id { get; set; }

    public string Descricao { get; set; } = string.Empty;

    public char Tipo { get; set; }

}

