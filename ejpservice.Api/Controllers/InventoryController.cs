using ejpservice.Domain.Entities;
using ejpservice.Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ejpservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepository _inventoryRepository;
        public InventoryController(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        // GET: api/<InventoryController>
        [HttpGet("GetInventory")]
        public async Task<IActionResult> Get()
        {
            var inventory = _inventoryRepository.GetInventory();
            return Ok(inventory);
        }

        [HttpGet("salesTotal")]
        public async Task<IActionResult> GetSalesTotal()
        {
            var sales = _inventoryRepository.GetSalesTotal();
            return Ok(sales);
        }

        // GET api/<InventoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var inventory = await _inventoryRepository.Get(id);
            if(inventory is null) return NotFound();

            return Ok(inventory);
        }

        // POST api/<InventoryController>
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] Inventory inventory)
        {
            try
            {
                if (inventory is null) return BadRequest("Inventory data is null");

                if (!ModelState.IsValid) return BadRequest(ModelState);

                inventory.CreationDate = DateTime.Now;
                inventory.UserCreation = 1;
                await _inventoryRepository.Save(inventory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

            return Ok(inventory);
        }

        // PUT api/<InventoryController>/5
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Inventory inventory)
        {
            inventory.UserMod = 1;

            try
            {
                await _inventoryRepository.Update(inventory);
            }catch (DbUpdateConcurrencyException)
            {
                if (!await _inventoryRepository.Exists(cd => cd.InventoryId == id))
                    return NotFound();
                else throw;
            }
            return NoContent();
        }

        // DELETE api/<InventoryController>/5
        [HttpPut("Delete/{inventoryId}")]
        public async Task<IActionResult> Delete(int inventoryId)
        {
            var inventory = await _inventoryRepository.Get(inventoryId);

            if (inventory is null)
                return NotFound();

            await _inventoryRepository.Remove(inventory);

            return NoContent();
        }
    }
}
