using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankBlazor.Api.Data.Entities;

public partial class Account
{
    [Key]
    public int AccountId { get; set; }

    [StringLength(50)]
    public string Frequency { get; set; } = null!;

    public DateOnly Created { get; set; }

    [Column(TypeName = "decimal(13, 2)")]
    public decimal Balance { get; set; }

    [InverseProperty("Account")]
    public virtual ICollection<Disposition> Dispositions { get; set; } = new List<Disposition>();

    [InverseProperty("Account")]
    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();

    [InverseProperty("Account")]
    public virtual ICollection<PermenentOrder> PermenentOrders { get; set; } = new List<PermenentOrder>();

    [InverseProperty("AccountNavigation")]
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
