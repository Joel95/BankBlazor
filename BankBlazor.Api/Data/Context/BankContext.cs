using BankBlazor.Api.Data.Entities;
using BankBlazor.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BankBlazor.Api.Data.Context
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions<BankContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}