namespace BankBlazor.Client.Services
{
    public class CustomerServiceClient
    {
        private readonly HttpClient _httpClient;
        public CustomerServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<DTOs.CustomerDTO?> GetCustomerAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<DTOs.CustomerDTO>($"api/customers/{id}");
        }
    }
}
