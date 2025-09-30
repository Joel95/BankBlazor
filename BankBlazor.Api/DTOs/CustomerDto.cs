namespace BankBlazor.Api.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<AccountDto> Accounts { get; set; } = new();
    }
}
