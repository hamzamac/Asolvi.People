using System;
using System.Collections.Generic;
using System.Text;

namespace JSONDb
{
    public interface IDataset<E>
    {
        IEnumerable<E> GetAll();
        object Find(int id);
        void Add(object value);
        void SaveChanges();
        void Update(object value);
        void Remove(int id);
    }
}
