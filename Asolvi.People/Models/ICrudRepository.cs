using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asolvi.People.Models
{
    public interface ICrudRepository<T> where T: class
    {
        void Add(T value);
        IEnumerable<T> GetAll();
        T Find(int id);
        void Update(T value);
        void Remove(int id);
    }
}
