using Microsoft.AspNetCore.Mvc;
using BankBlazor.Api.Services;

namespace BankBlazor.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly CustomerService _customerService;
        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await _customerService.GetCustomerAsync(id);
            if (customer == null) return NotFound($"Customer with ID {id} not found.");
            return Ok(customer);
        }

    }
}