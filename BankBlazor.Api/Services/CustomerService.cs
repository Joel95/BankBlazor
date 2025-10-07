using BankBlazor.Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using BankBlazor.Api.Data.Entities;
using BankBlazor.Api.DTOs;

namespace BankBlazor.Api.Services
{
    public class CustomerService
    {
        private readonly BankContext _context;
        public CustomerService(BankContext context)
        {
            _context = context;
        }

        public async Task<CustomerDTO?> GetCustomerAsync(int id)
        {
            var customer = await _context.Customers
                  .Include(c => c.Dispositions)
                    .ThenInclude(d => d.Account)
                    .ThenInclude(a => a.Transactions)
                    .FirstOrDefaultAsync(c => c.CustomerId == id);

            if (customer == null) return null;

            return new CustomerDTO
            {
                Id = customer.CustomerId,
                Name = $"{customer.Givenname} {customer.Surname}",
                Email = customer.Emailaddress,
                Phone = customer.Telephonenumber,
                Accounts = customer.Dispositions
                .Select(d => new AccountDTO
                {
                    Id = d.Account.AccountId,
                    Balance = d.Account.Balance,
                    Frequency = d.Account.Frequency,
                    Transactions = d.Account.Transactions.Select(t => new TransactionDTO
                    {
                        Id = t.TransactionId,
                        Amount = t.Amount,
                        Date = t.Date,
                        Type = t.Type,
                        Operation = t.Operation,
                        Balance = t.Balance,
                    }).ToList()
                }).ToList()
            };

        }
    }
}
