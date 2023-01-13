using Microsoft.AspNetCore.Mvc;
using WIN_sellingApp.Data;
using WIN_sellingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace WIN_sellingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CustomersController (ApplicationDbContext context)
        {
            _context = context;
        }

        // Get: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> AllCustomers()
        {
            if(_context.customers == null)
            {
                return NotFound();
            }
            return Ok(await _context.customers.ToListAsync());
        }

        // Get: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            if (_context.customers == null)
            {
                return NotFound();
            }
            var customer = await _context.customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }

        // Post: api/Customers
        [HttpPost]
        public async Task<ActionResult<Customer>> AddCustomer(Customer customer)
        {
           
            if (_context.customers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Customer'  is null.");
            }
               
            _context.customers.Add(customer);
           await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.Customerid }, customer);
        }
    }
}