using Microsoft.AspNetCore.Mvc;
using PersonApi.Services;
using Shared;

namespace PersonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        public PersonsController(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        private readonly IPersonRepository personRepository;

        // GET api/persons
        [HttpGet]
        public ActionResult<Person[]> Get()
        {
            return personRepository.GetAll();
        }

        // GET api/persons/5
        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
            var person = personRepository.Get(id);
            if (person != null)
            {
                return Ok(person);
            }
            else
            {
                return NotFound(id);
            }
        }

        // POST api/persons
        [HttpPost]
        public ActionResult<Person> Post([FromBody] Person person)
        {
            return personRepository.Add(person);
        }

        // PUT api/persons/5
        [HttpPut("{id}")]
        public ActionResult<Person> Put(int id, [FromBody] Person person)
        {
            var updatedPerson = personRepository.Update(person);
            if (updatedPerson != null)
            {
                return Ok(updatedPerson);
            }
            else
            {
                return NotFound(person);
            }
        }

        // DELETE api/persons/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = personRepository.Remove(id);
            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound(id);
            }
        }
    }
}
