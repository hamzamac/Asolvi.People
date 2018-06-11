using JsonFileDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asolvi.People.Models
{
    public class LocationRepository : ICrudRepository<Location>
    {
        private readonly ApplicationDBContext _db;

        public LocationRepository(IDBContext db) => _db = (ApplicationDBContext)db;

        public void Add(Location location)
        {
            _db.Locations.Add(location);
            _db.SaveChanges();
        }

        public IEnumerable<Location> GetAll() => _db.Locations.GetAll();

        public Location Find(int id) => _db.Locations.Find(id);

        public void Update(Location location)
        {
            _db.Locations.Update(location);
            _db.SaveChanges();
        }

        public void Remove(int id)
        {
            _db.Locations.Remove(id);
            _db.SaveChanges();
        }
    }
}
