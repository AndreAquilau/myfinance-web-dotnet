using MyFinanceWeb.Application.DTOs.PlanoContaDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinanceWeb.Application.DTOs.TransacaoDTOs;

public record TransacaoDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo Historico é obrigatório.")]
    [MinLength(3, ErrorMessage = "O campo Historico deve ter no mínimo 3 caracteres.")]
    [MaxLength(3, ErrorMessage = "O campo Historico deve ter no máximo 256 caracteres.")]
    [DisplayName("Historico")]
    public string Historico { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo Valor é obrigatório.")]
    [DisplayName("Valor")]
    public decimal Valor { get; set; }

    [Required(ErrorMessage = "Campo Data é obrigatório.")]
    [DisplayName("Data")]
    public DateTime Data { get; set; }

    public int PlanoContaId { get; set; }

    public required PlanoContaDTO PlanoConta { get; set; }
}

