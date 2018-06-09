using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace JSONDb
{
    public class Dataset<E>: IDataset<E>
    {
        public JObject table { get; set; }

        public Dataset(JObject database)
        {
            //extract corresponding table to E
            table = (JObject)database["person"];
        }

        public void Add(object value)
        {
            throw new NotImplementedException();
        }

        public object Find(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(object value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<E> GetAll()
        {

            IList<E> entities = table["rows"].ToObject<IList<E>>();
            return entities;
        }
    }
}
