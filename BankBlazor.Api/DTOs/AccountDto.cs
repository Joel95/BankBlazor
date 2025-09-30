namespace BankBlazor.Api.DTOs
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; } = "";
        public decimal Balance { get; set; }
        public string AccountType { get; set; } = "";
        public List<TransactionDto> Transactions { get; set; } = new();

    }
}
