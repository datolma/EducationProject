using EducationProject.Core.Application.Services;
using EducationProject.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace EducationProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoodsController : ControllerBase
    {
        private readonly EducationService _service;

        public GoodsController(EducationService service)
        {
            _service = service;
        }

        // GET: api/goods
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var goods = await _service.GetAllGoodsAsync();
            return Ok(goods);
        }

        // GET: api/goods/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var good = await _service.GetGoodByIdAsync(id);
            if (good == null)
                return NotFound($"Товар с ID {id} не найден");

            return Ok(good);
        }

        // POST: api/goods
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Good good)
        {
            try
            {
                var created = await _service.AddGoodAsync(good);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/goods
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Good good)
        {
            try
            {
                var updated = await _service.UpdateGoodAsync(good);
                return Ok(updated);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/goods/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteGoodAsync(id);
            if (!deleted)
                return NotFound($"Товар с ID {id} не найден");

            return NoContent();
        }

        // GET: api/goods/search?name=ноут
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Введите название для поиска");

            var goods = await _service.SearchGoodsByNameAsync(name);
            return Ok(goods);
        }

        [HttpGet("{id}/finalprice")]
        public async Task<IActionResult> GetFinalPrice(int id)
        {
            try
            {
                var finalPrice = await _service.GetFinalPriceAsync(id);
                return Ok(new { goodId = id, finalPrice });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
