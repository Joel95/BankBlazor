using BankBlazor.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Security.Principal;

namespace BankBlazor.Api.Services
{
    public class AccountService
    {
        private readonly BankContext _context;
        public AccountService(BankContext context)
        {
            _context = context;
        }

        public async Task<bool> DepositAsync(int accountId, decimal amount)
        {
            var account = await _context.Accounts.FindAsync(accountId);
            if (account == null) return false;

            account.Balance += amount;

            _context.Transactions.Add(new Transaction
            {
                AccountId = accountId,
                Type = "Deposit",
                Operation = "Cash Deposit",
                Amount = amount,
                Balance = account.Balance,
                Date = DateOnly.FromDateTime(DateTime.Now)
            });
        }

        public async Task<bool> WithdrawAsync(int accountId, decimal amount)
        {
            var account = await _context.Accounts.FindAsync(accountId);
            if (account == null || account.Balance < amount) return false;
            account.Balance -= amount;
            _context.Transactions.Add(new Transaction
            {
                AccountId = accountId,
                Type = "Withdrawal",
                Operation = "Cash Withdrawal",
                Amount = amount,
                Balance = account.Balance,
                Date = DateOnly.FromDateTime(DateTime.Now)
            });
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> TransferAsync(int fromAccountId, int toAccountId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var fromAccount = await _context.Accounts.FindAsync(fromAccountId);
                var toAccount = await _context.Accounts.FindAsync(toAccountId);
                if (fromAccount == null || toAccount == null || fromAccount.Balance < 0)
                    return false;
                decimal amount = fromAccount.Balance;
                fromAccount.Balance -= amount;
                toAccount.Balance += amount;
                _context.Transactions.Add(new Transaction
                {
                    AccountId = fromAccountId,
                    Type = "Transfer out",
                    Operation = $"Transfer to Account {toAccountId}",
                    Amount = amount,
                    Balance = fromAccount.Balance,
                    Date = DateOnly.FromDateTime(DateTime.Now)
                });
                _context.Transactions.Add(new Transaction
                {
                    AccountId = toAccountId,
                    Type = "Transfer In ",
                    Operation = $"Transfer from Account {fromAccountId}",
                    Amount = amount,
                    Balance = toAccount.Balance,
                    Date = DateOnly.FromDateTime(DateTime.Now)
                });
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                return false;
            }
        }

    }
}
