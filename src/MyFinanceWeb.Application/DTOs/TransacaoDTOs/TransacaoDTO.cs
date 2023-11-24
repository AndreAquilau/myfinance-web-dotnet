using MyFinanceWeb.Application.DTOs.PlanoContaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinanceWeb.Application.DTOs.TransacaoDTOs;

public record TransacaoDTO
{
    public int Id { get; set; }

    public string Historico { get; set; } = string.Empty;

    public decimal Valor { get; set; }

    public DateTime Data { get; set; }

    public int PlanoContaId { get; set; }

    public required PlanoContaReadDTO PlanoConta { get; set; }
}

