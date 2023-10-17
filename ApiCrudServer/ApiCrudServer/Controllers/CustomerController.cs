using ApiCrudServer.Data;
using ApiCrudServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public CustomerController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomer()
        {
            var customers = await _context.Customers.ToListAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            var customer = _context.Customers.Find(id);
            if(customer == null)
            {
                return NotFound();
            }
            return customer;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Create(Customer customer)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id , Customer customer)
        {
            if (id != customer.Id)
                return BadRequest();
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if(customer == null )
            {
                return NotFound("Incorrect customer id");
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return Ok();

        }




    }
}
