using BankBlazor.Api.Data.Context;
using BankBlazor.Api.Models;
using BankBlazor.Api.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BankBlazor.Api.Services
{
    public class CustomerService
    {
        private readonly BankContext _context;
        public CustomerService(BankContext context)
        {
            _context = context;
        }
        public async Task<CustomerDto?> GetCustomersAsync(int id)
        {
            var customer = await _context.Customers
            .Include(c => c.Accounts)
            .ThenInclude(a => a.Transactions)
            .FirstOrDefaultAsync(c => c.Id == id);

            if (customer == null) return null;

            return new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
                Accounts = customer.Accounts.Select(a => new AccountDto
                {
                    Id = a.Id,
                    AccountNumber = a.AccountNumber,
                    Balance = a.Balance,
                    AccountType = a.AccountType,
                    Transactions = a.Transactions.Select(t => new TransactionDto
                    {
                        Id = t.Id,
                        Type = t.Type,
                        Amount = t.Amount,
                        Date = t.Date
                    }).ToList()
                }).ToList()
            };
        }
       
      
    }
}
