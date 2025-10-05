using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankBlazor.Api.Data.Entities;

public partial class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [StringLength(6)]
    public string Gender { get; set; } = null!;

    [StringLength(100)]
    public string Givenname { get; set; } = null!;

    [StringLength(100)]
    public string Surname { get; set; } = null!;

    [StringLength(100)]
    public string Streetaddress { get; set; } = null!;

    [StringLength(100)]
    public string City { get; set; } = null!;

    [StringLength(15)]
    public string Zipcode { get; set; } = null!;

    [StringLength(100)]
    public string Country { get; set; } = null!;

    [StringLength(2)]
    public string CountryCode { get; set; } = null!;

    public DateOnly? Birthday { get; set; }

    [StringLength(20)]
    public string? NationalId { get; set; }

    [StringLength(10)]
    public string? Telephonecountrycode { get; set; }

    [StringLength(25)]
    public string? Telephonenumber { get; set; }

    [StringLength(100)]
    public string? Emailaddress { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Disposition> Dispositions { get; set; } = new List<Disposition>();
}
