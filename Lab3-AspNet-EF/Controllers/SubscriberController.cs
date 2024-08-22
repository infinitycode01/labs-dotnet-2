using Lab3_AspNet_EF.Models;
using Lab3_AspNet_EF.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Lab3_AspNet_EF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriberController : ControllerBase
    {
        private readonly IBaseRepository<Subscriber> _repository;

        public SubscriberController(IBaseRepository<Subscriber> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Subscriber>> GetAll()
        {
            var subscribers = _repository.GetAll();
            return Ok(subscribers);
        }

        [HttpGet("{id}")]
        public ActionResult<Subscriber> GetById(int id)
        {
            var subscriber = _repository.GetId(id);
            if (subscriber == null)
            {
                return NotFound();
            }
            return Ok(subscriber);
        }

        [HttpPost]
        public ActionResult<Subscriber> Create([FromBody] Subscriber subscriber)
        {
            if (subscriber == null)
            {
                return BadRequest("Subscriber cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Add(subscriber);
            return CreatedAtAction(nameof(GetById), new { id = subscriber.SubscriberId }, subscriber);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Subscriber subscriber)
        {
            if (subscriber == null || subscriber.SubscriberId != id)
            {
                return BadRequest("Subscriber ID mismatch.");
            }

            var existingSubscriber = _repository.GetId(id);
            if (existingSubscriber == null)
            {
                return NotFound();
            }

            _repository.Update(subscriber);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var subscriber = _repository.GetId(id);
            if (subscriber == null)
            {
                return NotFound();
            }

            _repository.Remove(subscriber);
            return NoContent();
        }
    }
}
