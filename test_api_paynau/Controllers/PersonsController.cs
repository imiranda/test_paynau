using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test_api_paynau.Interfaces;
using test_api_paynau.Models;

namespace test_api_paynau.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IRepository<Person> personRepository;

        public PersonsController(IRepository<Person> _personRepository)
        {
            personRepository = _personRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            var persons = await personRepository.GetAllAsync();
            return Ok(persons);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await personRepository.GetByIdAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            await personRepository.AddAsync(person);
            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            await personRepository.UpdateAsync(person);

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await personRepository.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            await personRepository.DeleteAsync(person);

            return NoContent();
        }
    }
}
