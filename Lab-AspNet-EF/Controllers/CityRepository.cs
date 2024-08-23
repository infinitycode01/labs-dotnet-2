using Lab3_AspNet_EF.Models;
using Lab3_AspNet_EF.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Lab3_AspNet_EF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly IBaseRepository<City> _repository;

        public CityController(IBaseRepository<City> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<City>> GetAll()
        {
            var cities = _repository.GetAll();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public ActionResult<City> GetById(int id)
        {
            var city = _repository.GetId(id);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        [HttpPost]
        public ActionResult<City> Create([FromBody] City city)
        {
            if (city == null)
            {
                return BadRequest("City cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Add(city);
            return CreatedAtAction(nameof(GetById), new { id = city.Id }, city);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] City city)
        {
            if (city == null || city.Id != id)
            {
                return BadRequest("City ID mismatch.");
            }

            var existingCity = _repository.GetId(id);
            if (existingCity == null)
            {
                return NotFound();
            }

            _repository.Update(city);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var city = _repository.GetId(id);
            if (city == null)
            {
                return NotFound();
            }

            _repository.Remove(city);
            return NoContent();
        }
    }
}
