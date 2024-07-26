using ejpservice.Domain.Entities;
using ejpservice.Domain.Interface;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ejpservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesRepository _salesRepository;
        public SalesController(ISalesRepository salesRepository)
        {
            _salesRepository = salesRepository;
        }

        // GET: api/<SalesController>
        [HttpGet("GetSales")]
        public async Task<IActionResult> Get()
        {
            var sales = _salesRepository.GetSales();
            return Ok(sales);
        }

        // GET api/<SalesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var sales = await _salesRepository.Get(id);
            if (sales is null) return NotFound();

            return Ok(sales);
        }

        // POST api/<SalesController>
        [HttpPost("Create")]
        public async Task <IActionResult> Post([FromBody] Sales salesAddModel)
        {
            try
            {
                if (salesAddModel is null) return BadRequest("Sales data is null");

                if (!ModelState.IsValid) return BadRequest(ModelState);

                salesAddModel.CreationDate = DateTime.Now;
                salesAddModel.UserCreation = 1;
                await _salesRepository.Save(salesAddModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
            return Ok(salesAddModel);
        }

        // PUT api/<SalesController>/5
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Sales sales)
        {
            sales.UserMod = 1;

            try
            {
                await _salesRepository.Update(sales);
            } catch(DbUpdateConcurrencyException)
            {
                if (!await _salesRepository.Exists(cd => cd.SaleId == id))
                    return NotFound();
                else throw;
            }

            return NoContent();
        }

        // DELETE api/<SalesController>/5
        [HttpPut("Delete/{salesId}")]
        public async Task<IActionResult> Delete(int salesId)
        {
            var sale = await _salesRepository.Get(salesId);

            if (sale is null)
                return NotFound();

            await _salesRepository.Remove(sale);

            return NoContent();
        }
    }
}
