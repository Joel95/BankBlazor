using BankBlazor.Api.Data.Context;
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

        public async Task<CustomerDTO>> GetCustomerAsync(int id)
        {
            var customer = await _context.Customers
                  .Include(c => c.Dispositions)
                    .ThenInclude(d => d.Account)
                    .ThenInclude(a => a.Transactions)
                    .FirstOrDefaultAsync(c => c.CustomerId == id);

            if (customer == null) return null;

            return new customerDTO
            {
                Id = customer.CustomerId,
                Name = $"{customer.Givenname} {customer.Surname}"
                Email = customer.Emailaddress,
                Phone = customer.TelephoneNumber,,
                Accounts = customer.Dispositions
                .Select(d => d.Account
                .Select(d => new AccountDTO
                {
                    Id = AccountId,
                    Balance = a.Balance,
                    Frequency = a.Frequency,
                    Transactions = a.Transactions.Select(t => new TransactionDTO
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
