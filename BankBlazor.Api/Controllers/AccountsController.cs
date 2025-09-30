using BankBlazor.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankBlazor.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountsController : ControllerBase
{
    private readonly AccountService _service;
    public AccountsController(AccountService service)
    {
        _service = service;
    }
    [HttpPost("{accountId}/deposit")]
    public async Task<IActionResult> Deposit(int accountId, decimal amount)
    {
        var result = await _service.DepositAsync(accountId, amount);
        if (!result) return BadRequest("Deposit failed.");
        return Ok("Deposit successful.");
    }
    [HttpPost("{accountId}/withdraw")]
    public async Task<IActionResult> Withdraw(int accountId, decimal amount)
    {
        var result = await _service.WithdrawAsync(accountId, amount);
        if (!result) return BadRequest("Withdrawal failed.");
        return Ok("Withdrawal successful.");
    }
    [HttpPost("transfer")]
    public async Task<IActionResult> Transfer(int fromAccountId, int toAccountId, decimal amount)
    {
        var result = await _service.TransferAsync(fromAccountId, toAccountId, amount);
        if (!result) return BadRequest("Transfer failed.");
        return Ok("Transfer successful.");
    }
}