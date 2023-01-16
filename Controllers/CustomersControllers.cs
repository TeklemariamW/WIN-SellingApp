using Microsoft.AspNetCore.Mvc;
using WIN_sellingApp.Data;
using WIN_sellingApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;

namespace WIN_sellingApp.Controllers
{
    [EnableCors("Customers")]
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
           // update authUsers
           // set Email = REPLACE(Email,'wintershalldea','okea')
           // where email like '%wintershalldea%';
           var allCustomers= _context.customers;
           foreach ( var cust in allCustomers){
            
            if (cust.Email != null){
                cust.Email = cust.Email.Replace("gmail.com","bouvet.no");
            }
            
           }

            //return Ok(await _context.customers.ToListAsync());
            return await allCustomers.OrderBy(n => n.Name)
            .ToListAsync();
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