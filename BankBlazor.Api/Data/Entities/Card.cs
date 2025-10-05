using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankBlazor.Api.Data.Entities;

public partial class Card
{
    [Key]
    public int CardId { get; set; }

    public int DispositionId { get; set; }

    [StringLength(50)]
    public string Type { get; set; } = null!;

    public DateOnly Issued { get; set; }

    [Column("CCType")]
    [StringLength(50)]
    public string Cctype { get; set; } = null!;

    [Column("CCNumber")]
    [StringLength(50)]
    public string Ccnumber { get; set; } = null!;

    [Column("CVV2")]
    [StringLength(10)]
    public string Cvv2 { get; set; } = null!;

    public int ExpM { get; set; }

    public int ExpY { get; set; }

    [ForeignKey("DispositionId")]
    [InverseProperty("Cards")]
    public virtual Disposition Disposition { get; set; } = null!;
}
