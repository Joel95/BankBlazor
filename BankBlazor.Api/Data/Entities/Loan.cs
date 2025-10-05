using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankBlazor.Api.Data.Entities;

public partial class Loan
{
    [Key]
    public int LoanId { get; set; }

    public int AccountId { get; set; }

    public DateOnly Date { get; set; }

    [Column(TypeName = "decimal(13, 2)")]
    public decimal Amount { get; set; }

    public int Duration { get; set; }

    [Column(TypeName = "decimal(13, 2)")]
    public decimal Payments { get; set; }

    [StringLength(50)]
    public string Status { get; set; } = null!;

    [ForeignKey("AccountId")]
    [InverseProperty("Loans")]
    public virtual Account Account { get; set; } = null!;
}
