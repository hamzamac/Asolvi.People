using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Asolvi.People.Models
{
    public class JsonDb: IJsonDb<Person>
    {
        private JObject _dataset;
        private JArray _table;  
        private string _jsonFilePath;
        private int _rowId;

        public JsonDb(IConfiguration configuration)
        {
            _jsonFilePath = configuration.GetConnectionString("JSONFilePath");
            _dataset = this.Fetch();
            _table = (JArray)_dataset["person"];
            _rowId = _table.Count();
        }

        // Read data from dataset
        private JObject Fetch()
        {
            JObject dataset;
            try
            {   
                if(!File.Exists(_jsonFilePath))
                {
                    //initialize a database file
                    File.WriteAllText(_jsonFilePath, "{'person':[]}");
                }
                using (StreamReader reader = File.OpenText(_jsonFilePath))
                {
                    dataset = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
                }
            }
            catch (Exception e)
            {   
                dataset = JObject.Parse("{'person':[]}");
                
            }

            return dataset;
        }           

        public void SaveChanges()
        {
            //save changes to json file on dis
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamWriter sw = new StreamWriter(_jsonFilePath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, _dataset);
            }
        }

        //Controls assignment of elememts IDs
        private int NextId()
        {
            return ++_rowId;
        }

        //Query Operation Methods

        public IList<Person> GetAll()
        {
            IList<Person> persons = _table.ToObject<IList<Person>>();
            return persons;
        }

        //finds a single person
        public Person Find(int id)
        {
            var person = _table.FirstOrDefault(p => p.ToObject<Person>().Id == id);
            if(person == null)
            {
                return null;
            }
            JsonSerializer serializer = new JsonSerializer();
            Person firstPerson = (Person)serializer.Deserialize(new JTokenReader(person), typeof(Person));
            
            return firstPerson;
        }

        public void Add(Person person)
        {
            person.Id = NextId();
            JObject personJson = (JObject)JToken.FromObject(person);
            _table.Add(personJson);
            
        }

        public void Update(Person person)
        {
            _table.FirstOrDefault(p => p.ToObject<Person>().Id == person.Id).Replace(JToken.FromObject(person));
        }

        public void Remove(int id)
        {
            _table.Remove(_table.FirstOrDefault(p => p.ToObject<Person>().Id == id));
        }
    }
}
