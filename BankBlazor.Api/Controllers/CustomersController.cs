using BankBlazor.Api.DTOs;
using BankBlazor.Api.Data.Context;
using BankBlazor.Api.Models;
using BankBlazor.Api.Services;
//using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankBlazor.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly CustomerService _service;
    public CustomersController(CustomerService service)
    {
        _service = service;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetCustomer(int id)
    {
        var customer = await _service.GetCustomersAsync(id);

        if (customer == null) return NotFound();
        return Ok(customer);
    }
}