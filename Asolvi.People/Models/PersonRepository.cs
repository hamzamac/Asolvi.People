using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asolvi.People.Models
{
    public class PersonRepository : ICrudRepository<Person>
    {
        private readonly IJsonDb<Person> _db;

        public PersonRepository(IJsonDb<Person> db) => _db = db;

        public void Add(Person person)
        {
            _db.Add(person);
            _db.SaveChanges();
        }

        public IEnumerable<Person> GetAll() => _db.GetAll();

        public Person Find(int id) => _db.Find(id);

        public void Update(Person person)
        {
            _db.Update(person);
            _db.SaveChanges();
        }

        public void Remove(int id)
        {
            _db.Remove(id);
            _db.SaveChanges();
        }

    }
}
