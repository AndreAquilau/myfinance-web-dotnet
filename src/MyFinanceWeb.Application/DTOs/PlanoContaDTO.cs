using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinanceWeb.Application.DTOs;

public record PlanoContaDTO
{
    public int Id { get; set; }

    public string Descricao { get; set; } = string.Empty;

    public char Tipo { get; set; }

    public required IEnumerable<TransacaoDTO> Transacoes { get; set; }
}

