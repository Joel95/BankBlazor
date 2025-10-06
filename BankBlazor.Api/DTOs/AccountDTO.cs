using System.Transactions;

namespace BankBlazor.Api.DTOs
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public string AccountType { get; set; } = string.Empty;

        public List<TransactionDto> Transactions { get; set; } = new();
    }
}
