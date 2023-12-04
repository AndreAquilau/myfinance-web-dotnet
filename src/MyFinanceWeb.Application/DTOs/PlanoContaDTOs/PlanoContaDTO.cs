using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFinanceWeb.Application.DTOs.TransacaoDTOs;

namespace MyFinanceWeb.Application.DTOs.PlanoContaDTOs;

public record PlanoContaDTO
{
    public int Id { get; set; }


    [Required(ErrorMessage = "Campo Descrição é obrigatório.")]
    [MinLength(3, ErrorMessage = "O campo Descrição deve ter no mínimo 3 caracteres.")]
    [MaxLength(3, ErrorMessage = "O campo Descrição deve ter no máximo 50 caracteres.")]
    [DisplayName("Descrição")]
    public string Descricao { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo Tipo é obrigatório.")]
    [MinLength(1, ErrorMessage = "O campo Tipo deve ter no mínimo 1 caracter.")]
    [MaxLength(1, ErrorMessage = "O campo Tipo deve ter no máximo 1 caracter.")]
    [DisplayName("Tipo")]
    public char Tipo { get; set; }
}

