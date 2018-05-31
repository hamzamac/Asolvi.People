using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asolvi.People.Models
{
    public interface IJsonDb<T>
    {
        IList<T> GetAll();
        T Find(int id);
        void Add(T value);
        void SaveChanges();
        void Update(T value);
        void Remove(int id);
    }
}
