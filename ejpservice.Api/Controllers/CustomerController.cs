using ejpservice.Api.Models.Create;
using ejpservice.Domain.Entities;
using ejpservice.Domain.Interface;
using ejpservice.Domain.Models;
using ejpservice.Infrastructure.Context;
using ejpservice.Infrastructure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ejpservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomersRepository _customersRepository;
        //private readonly EJPServiceContext _context;
        public CustomerController(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }
        // GET: api/<CustomerController>
        [HttpGet("GetCustomer")]
        public async Task<IActionResult> Get()
        {
            var customers = _customersRepository.GetCustomers();
            return Ok(customers);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _customersRepository.Get(id);

            if(customer is null) return NotFound();

            return Ok(customer);
        }

        // POST api/<CustomerController>
        [HttpPost("New")]
        public async Task<IActionResult> Post([FromBody] Customers customerAddModel)
        {
            try
            {
                if (customerAddModel is null) return BadRequest("Customer data is null");

                if (!ModelState.IsValid) return BadRequest(ModelState);

                customerAddModel.CreationDate = DateTime.Now;
                customerAddModel.UserCreation = 1;
                await _customersRepository.Save(customerAddModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

            return Ok(customerAddModel);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Customers customers)
        {
            customers.UserMod = 1;

            try
            {
                await  _customersRepository.Update(customers);
            } catch (DbUpdateConcurrencyException)
            {
                if (!await _customersRepository.Exists(cd => cd.CustomerId == id)) return NotFound();
                else throw ;
            }

            return NoContent();
        }

        // DELETE api/<CustomerController>/5
        [HttpPut("Delete/{customerId}")]
        public async Task<IActionResult> Delete(int customerId)
        {
            var customer = await _customersRepository.Get(customerId);

            if (customer is null) 
                return NotFound();

            await _customersRepository.Remove(customer);

            return NoContent();
        }
    }
}
