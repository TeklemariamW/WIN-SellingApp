using Microsoft.AspNetCore.Mvc;
using WIN_sellingApp.Data;
using WIN_sellingApp.Models;

namespace WIN_sellingApp.Controllers
{
    [Route("api([controller])")]
    [ApiController]
    public class CustomerCarsController : Controller 
    {
        private readonly ApplicationDbContext _context;
        public CustomerCarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Getting combination of customers and cars
        // Get: api/CustomerCars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> CustomerAndCars()
        {
            //TODO: getting from both customers and cars table
            return  Ok();
        }
    }
}