namespace BankBlazor.Client.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public List<AccountDTO> Accounts { get; set; } = new();
    }
}
