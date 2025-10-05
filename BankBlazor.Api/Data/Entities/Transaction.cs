using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankBlazor.Api.Data.Entities;

[Index("AccountId", Name = "IX_Transactions_AccountId")]
public partial class Transaction
{
    [Key]
    public int TransactionId { get; set; }

    public int AccountId { get; set; }

    public DateOnly Date { get; set; }

    [StringLength(50)]
    public string Type { get; set; } = null!;

    [StringLength(50)]
    public string Operation { get; set; } = null!;

    [Column(TypeName = "decimal(13, 2)")]
    public decimal Amount { get; set; }

    [Column(TypeName = "decimal(13, 2)")]
    public decimal Balance { get; set; }

    [StringLength(50)]
    public string? Symbol { get; set; }

    [StringLength(50)]
    public string? Bank { get; set; }

    [StringLength(50)]
    public string? Account { get; set; }

    [ForeignKey("AccountId")]
    [InverseProperty("Transactions")]
    public virtual Account AccountNavigation { get; set; } = null!;
}
