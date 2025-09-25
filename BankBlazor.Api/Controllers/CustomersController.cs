using BankBlazor.Api.Data.Context;
using BankBlazor.Api.Data.Entities;
//using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankBlazor.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly BankContext _context;
    public CustomersController(BankContext context) => _context = context;

    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetCustomer(int id)
    {
        var customer = await _context.Customers
            .Include(c => c.Accounts)
            .ThenInclude(a => a.Transactions)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (customer == null) return NotFound();
        return customer;
    }
}