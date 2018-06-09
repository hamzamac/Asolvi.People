using JSONDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JSONDb;

namespace Asolvi.People.Models
{
    public class PersonRepository : ICrudRepository<Person>
    {
        private readonly PeopoleDbContext _db;

        public PersonRepository(IDBContext db) => _db = (PeopoleDbContext)db;

        public void Add(Person person)
        {
            _db.Persons.Add(person);
            _db.Persons.SaveChanges();
        }

        public IEnumerable<Person> GetAll() => _db.Persons.GetAll();

        public Person Find(int id) => (Person)_db.Persons.Find(id);

        public void Update(Person person)
        {
            _db.Persons.Update(person);
            _db.Persons.SaveChanges();
        }

        public void Remove(int id)
        {
            _db.Persons.Remove(id);
            _db.Persons.SaveChanges();
        }

    }
}
