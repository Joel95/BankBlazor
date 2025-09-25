namespace BankBlazor.Client.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public List<AccountModel> AccountModels { get; set; } = new List<AccountModel>();
    }
}
