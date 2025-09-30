using BankBlazor.Api.Models;

namespace BankBlazor.Api.Models
{
    public class Account
    {
        public int Id { get; set; }

        public string AccountType { get; set; } = "";
        public int CustomerId { get; set; }
        public Customer customer { get; set; } = null!;
        public string AccountNumber { get; set; } = "";
        public decimal Balance { get; set; }

        public List<Transaction> Transactions { get; set; } = new();

    }
}