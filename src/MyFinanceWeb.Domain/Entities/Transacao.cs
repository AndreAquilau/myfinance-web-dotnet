using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFinanceWeb.Domain.Entities;

public class Transacao
{
    // PK auto increment
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Historico { get; set; } = string.Empty;

    public decimal Valor { get; set; }

    public DateTime Data { get; set; }

    public int PlanoContaId { get; set; }

    public PlanoConta? PlanoConta { get; set; }

}




