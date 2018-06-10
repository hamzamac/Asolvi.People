using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace JSONDb
{
    public class Dataset<E>: IDataset<E>
    {
        private JArray table;

        public Dataset(JObject database)
        {
            //extract corresponding table to E
            var tableName = typeof(E).Name.ToLower();
            table = (JArray)database[tableName]["rows"];

            //create tableof type E if not exists
            if(table == null)
            {
                database.Add(tableName, JToken.Parse("{'values':[],'index':0}"));
                table = (JArray)database[tableName]["rows"];
            }
        }

        public IEnumerable<E> GetAll()
        {
            IList<E> entities = table.ToObject<IList<E>>();
            return entities;
        }

        public void Add(E entity)
        {
            //entity.Id = NextId();
            JObject entityJson = (JObject)JToken.FromObject(entity);
            table.Add(entityJson);
        }

        public object Find(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            //table.Remove(table["rows"].FirstOrDefault(p => p.ToObject<E>().Id == id));
        }

        public void Update(E entity)
        {
            //table["rows"].FirstOrDefault(p => p.ToObject<E>().Id == person.Id).Replace(JToken.FromObject(entity));
        }
    }
}
