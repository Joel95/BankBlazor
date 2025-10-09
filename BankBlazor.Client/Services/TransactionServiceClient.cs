namespace BankBlazor.Client.Services
{
    public class TransactionServiceClient
    {
        private readonly HttpClient _httpClient;
        public TransactionServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<DTOs.TransactionDTO>?> GetTransactionsByAccountIdAsync(int accountId)
        {
            return await _httpClient.GetFromJsonAsync<List<DTOs.TransactionDTO>?>($"api/transactions/account/{accountId}");
        }

        public async Task<bool> DepositAsync(int accountId, decimal amount)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/transactions/deposit", new { accountId, amount });
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> WithdrawAsync(int accountId, decimal amount)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/transactions/withdraw", new { accountId, amount });
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> TransferAsync(int fromAccountId, int toAccountId, decimal amount)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/transactions/transfer", new { fromAccountId, toAccountId, amount });
            return response.IsSuccessStatusCode;
        }
    }
}
