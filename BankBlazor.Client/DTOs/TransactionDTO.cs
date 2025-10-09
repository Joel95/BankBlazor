namespace BankBlazor.Client.DTOs
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Operation { get; set; } = string.Empty;
        public decimal Balance { get; set; }
    }
}
