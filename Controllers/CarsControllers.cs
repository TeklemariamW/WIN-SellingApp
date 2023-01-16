using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WIN_sellingApp.Data;
using WIN_sellingApp.Models;

namespace WIN_sellingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CarsController(ApplicationDbContext contex)
        {
            _context =contex;
        }

        // Get : api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> AllCars()
        {
            if (_context.cars == null)
            {
                return NotFound();
            }
            return await _context.cars.ToListAsync();
        }

        // Get: api/Cars/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            if (_context.cars == null)
            {
                return NotFound();
            }

            var car = await _context.cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return car;
        }

        // Post: api/Cars
        [HttpPost]
        public async Task<ActionResult<Car>> AddCar(Car car)
        {
            if (_context.cars == null)
            {
                return Problem("Can't add this form. one or more field is not field properly");
            }

            _context.cars.Add(car);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCar",new {id = car.Carid}, car);
        }
    }
}