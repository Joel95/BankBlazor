using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankBlazor.Api.Data.Entities;

[Table("User")]
public partial class User
{
    [Key]
    [Column("UserID")]
    public int UserId { get; set; }

    [StringLength(40)]
    public string LoginName { get; set; } = null!;

    [MaxLength(64)]
    public byte[] PasswordHash { get; set; } = null!;

    [StringLength(40)]
    public string? FirstName { get; set; }

    [StringLength(40)]
    public string? LastName { get; set; }
}
