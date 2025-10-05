using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankBlazor.Api.Data.Entities;

[Table("PermenentOrder")]
public partial class PermenentOrder
{
    [Key]
    public int OrderId { get; set; }

    public int AccountId { get; set; }

    [StringLength(50)]
    public string BankTo { get; set; } = null!;

    [StringLength(50)]
    public string AccountTo { get; set; } = null!;

    [Column(TypeName = "decimal(13, 2)")]
    public decimal? Amount { get; set; }

    [StringLength(50)]
    public string Symbol { get; set; } = null!;

    [ForeignKey("AccountId")]
    [InverseProperty("PermenentOrders")]
    public virtual Account Account { get; set; } = null!;
}
