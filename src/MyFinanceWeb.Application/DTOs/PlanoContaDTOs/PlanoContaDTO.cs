using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyFinanceWeb.Application.DTOs.PlanoContaDTOs;

public record PlanoContaDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo Descrição é obrigatório.")]
    [MinLength(3, ErrorMessage = "O campo Descrição deve ter no mínimo 3 caracteres.")]
    [MaxLength(50, ErrorMessage = "O campo Descrição deve ter no máximo 50 caracteres.")]
    [DisplayName("Descrição")]
    public string Descricao { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo Tipo é obrigatório.")]
    [MinLength(1, ErrorMessage = "O campo Tipo deve ter no mínimo 1 caracter.")]
    [MaxLength(1, ErrorMessage = "O campo Tipo deve ter no máximo 1 caracter.")]
    [DisplayName("Tipo")]
    public string Tipo { get; set; }
}

