using System.Transactions;

namespace BankBlazor.Api.DTOs
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public string AccountType { get; set; } = string.Empty;
        public string Frequency { get; set; } = string.Empty;
        public List<TransactionDTO> Transactions { get; set; } = new();
    }
}
