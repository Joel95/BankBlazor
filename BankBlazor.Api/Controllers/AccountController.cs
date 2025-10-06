using BankBlazor.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankBlazor.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("id")]

        public async Task<IActionResult> GetAccount(int id)
        {
            var account = await _accountService.GetAccountByIdAsync(id);
            if (account == null) return NotFound();
            return Ok(account);
        }

        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit(int accountId, decimal amount)
        {
            var result = await _accountService.DepositAsync(accountId, amount);
            if (!result) return BadRequest("Deposit failed");
            return Ok("Deposit successful");
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw(int accountId, decimal amount)
        {
            var result = await _accountService.WithdrawAsync(accountId, amount);
            if (!result) return BadRequest("Withdrawal failed");
            return Ok("Withdrawal successful");
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> Transfer(int fromAccountId, int toAccountId, decimal amount)
        {
            var result = await _accountService.TransferAsync(fromAccountId, toAccountId, amount);
            if (!result) return BadRequest("Transfer failed");
            return Ok("Transfer successful");
        }
    }
}
