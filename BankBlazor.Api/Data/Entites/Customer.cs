using BankBlazor.Api.Models;

namespace BankBlazor.Api.Data.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public List<Account> Accounts { get; set; } = new();
    }
}
