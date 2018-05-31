using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Asolvi.People.Models;

namespace Asolvi.People.Controllers
{
    [Route("api/[controller]")]
    public class PersonsController : Controller
    {
        private readonly ICrudRepository<Person> _repository;

        public PersonsController(ICrudRepository<Person> repository)
        {
            _repository = repository;
        }

        // GET api/persons
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _repository.GetAll();
        }

        // GET api/persons/id
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return _repository.Find(id);
        }

        // POST api/persons
        [HttpPost]
        public IActionResult Post([FromBody]Person person)
        {
            if(person == null)
            {
                BadRequest();
            }
            _repository.Add(person);

            return new NoContentResult();
        }

        // PUT api/persons/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Person newPerson)
        {
            if(newPerson == null || newPerson.Id != id)
            {
                BadRequest();
            }

            var oldPerson = _repository.Find(id);
            if(oldPerson == null)
            {
                NotFound();
            }

            _repository.Update(newPerson);
            return new NoContentResult();
        }

        // DELETE api/persons/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var person = _repository.Find(id);
            if (person == null)
            {
                BadRequest();
            }
            _repository.Remove(id);
            return new NoContentResult();
        }
    }
}
