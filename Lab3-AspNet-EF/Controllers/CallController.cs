using Lab3_AspNet_EF.Models;
using Lab3_AspNet_EF.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Lab3_AspNet_EF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CallController : ControllerBase
    {
        private readonly IBaseRepository<Call> _repository;

        public CallController(IBaseRepository<Call> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Call>> GetAll()
        {
            var calls = _repository.GetAll();
            return Ok(calls);
        }

        [HttpGet("{id}")]
        public ActionResult<Call> GetById(int id)
        {
            var call = _repository.GetId(id);
            if (call == null)
            {
                return NotFound();
            }
            return Ok(call);
        }

        [HttpPost]
        public ActionResult<Call> Create([FromBody] Call call)
        {
            if (call == null)
            {
                return BadRequest("Call cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Add(call);
            return CreatedAtAction(nameof(GetById), new { id = call.CallId }, call);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Call call)
        {
            if (call == null || call.CallId != id)
            {
                return BadRequest("Call ID mismatch.");
            }

            var existingCall = _repository.GetId(id);
            if (existingCall == null)
            {
                return NotFound();
            }

            _repository.Update(call);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var call = _repository.GetId(id);
            if (call == null)
            {
                return NotFound();
            }

            _repository.Remove(call);
            return NoContent();
        }
    }
}
