using Microsoft.AspNetCore.Mvc;
using BankBlazor.Api.Data.Context;
using BankBlazor.Api.Models;
using Microsoft.EntityFrameworkCore;


namespace BankBlazor.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly BankContext _context;

        public TransactionController(BankContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
        {
            return await _context.Transactions.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);

            if (transaction == null) return NotFound();
            return transaction;
        }

        [HttpPost]
        public async Task<ActionResult<Transaction>> CreateTransaction(Transaction transaction)
        {
            transaction.Date = DateTime.Now;
            _context.Transactions.Add(transaction);
             await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTransaction), new { id = transaction.Id }, transaction);
        }

    }
}
