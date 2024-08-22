using Lab3_AspNet_EF.Models;
using Lab3_AspNet_EF.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Lab3_AspNet_EF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneController : ControllerBase
    {
        private readonly IBaseRepository<Phone> _repository;

        public PhoneController(IBaseRepository<Phone> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Phone>> GetAll()
        {
            var phones = _repository.GetAll();
            return Ok(phones);
        }

        [HttpGet("{id}")]
        public ActionResult<Phone> GetById(int id)
        {
            var phone = _repository.GetId(id);
            if (phone == null)
            {
                return NotFound();
            }
            return Ok(phone);
        }

        [HttpPost]
        public ActionResult<Phone> Create([FromBody] Phone phone)
        {
            if (phone == null)
            {
                return BadRequest("Phone cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Add(phone);
            return CreatedAtAction(nameof(GetById), new { id = phone.Id }, phone);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Phone phone)
        {
            if (phone == null || phone.Id != id)
            {
                return BadRequest("Phone ID mismatch.");
            }

            var existingPhone = _repository.GetId(id);
            if (existingPhone == null)
            {
                return NotFound();
            }

            _repository.Update(phone);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var phone = _repository.GetId(id);
            if (phone == null)
            {
                return NotFound();
            }

            _repository.Remove(phone);
            return NoContent();
        }
    }
}
