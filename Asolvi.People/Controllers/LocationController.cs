using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asolvi.People.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asolvi.People.Controllers
{
    [Produces("application/json")]
    [Route("api/Location")]
    public class LocationController : Controller
    {
        private readonly ICrudRepository<Location> _repository;

        public LocationController(ICrudRepository<Location> repository)
        {
            _repository = repository;
        }

        // GET: api/Location
        [HttpGet]
        public IEnumerable<Location> Get()
        {
            return _repository.GetAll();
        }

        // GET: api/Location/5
        [HttpGet("{id}", Name = "Get")]
        public Location Get(int id)
        {
            return _repository.Find(id);
        }
        
        // POST: api/Location
        [HttpPost]
        public IActionResult Post([FromBody]Location location)
        {
            if (location == null)
            {
                BadRequest();
            }
            _repository.Add(location);

            return new NoContentResult();
        }
        
        // PUT: api/Location/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Location newLocation)
        {
            if (newLocation == null || newLocation.Id != id)
            {
                BadRequest();
            }

            var oldLocation = _repository.Find(id);
            if (oldLocation == null)
            {
                NotFound();
            }

            _repository.Update(newLocation);
            return new NoContentResult();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var location = _repository.Find(id);
            if (location == null)
            {
                BadRequest();
            }
            _repository.Remove(id);
            return new NoContentResult();
        }
    }
}
