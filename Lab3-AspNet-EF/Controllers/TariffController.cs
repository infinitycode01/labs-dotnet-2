using Lab3_AspNet_EF.Models;
using Lab3_AspNet_EF.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Lab3_AspNet_EF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TariffController : ControllerBase
    {
        private readonly IBaseRepository<Tariff> _repository;

        public TariffController(IBaseRepository<Tariff> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Tariff>> GetAll()
        {
            var tariffs = _repository.GetAll();
            return Ok(tariffs);
        }

        [HttpGet("{id}")]
        public ActionResult<Tariff> GetById(int id)
        {
            var tariff = _repository.GetId(id);
            if (tariff == null)
            {
                return NotFound();
            }
            return Ok(tariff);
        }

        [HttpPost]
        public ActionResult<Tariff> Create([FromBody] Tariff tariff)
        {
            if (tariff == null)
            {
                return BadRequest("Tariff cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Add(tariff);
            return CreatedAtAction(nameof(GetById), new { id = tariff.Id }, tariff);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Tariff tariff)
        {
            if (tariff == null || tariff.Id != id)
            {
                return BadRequest("Tariff ID mismatch.");
            }

            var existingTariff = _repository.GetId(id);
            if (existingTariff == null)
            {
                return NotFound();
            }

            _repository.Update(tariff);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var tariff = _repository.GetId(id);
            if (tariff == null)
            {
                return NotFound();
            }

            _repository.Remove(tariff);
            return NoContent();
        }
    }
}
