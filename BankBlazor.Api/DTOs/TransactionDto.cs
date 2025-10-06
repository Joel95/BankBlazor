namespace BankBlazor.Api.DTOs
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } = string.Empty;
    }
}
