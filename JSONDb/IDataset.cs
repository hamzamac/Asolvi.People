using System;
using System.Collections.Generic;
using System.Text;

namespace JSONDb
{
    public interface IDataset<E>
    {
        IEnumerable<E> GetAll();
        object Find(int id);
        void Add(E value);
        void Update(E value);
        void Remove(int id);
    }
}
