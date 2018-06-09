using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JSONDb
{
    public class DBContext: IDBContext
    {
        protected JObject database;

        public DBContext(string jsonFilePath)
        {
            //get DB location from configuration

            //initialize the database => fetch
            this.database = this.Fetch(jsonFilePath).GetAwaiter().GetResult();
        }

        public IDataset<ITable> ToTable()
        {

            database.Children().Values("Person");
            throw new NotImplementedException();
        }

        private async Task<JObject> Fetch(string jsonFilePath)
        {
            JObject database;
            try
            {
                if (!File.Exists(jsonFilePath))
                {
                    //TODO initialize a database file with all attributes of Dataset object
                    File.WriteAllText(jsonFilePath, "{'item':[],'indexTracker': 0}");
                }
                using (StreamReader reader = File.OpenText(jsonFilePath))
                {
                    database = (JObject)await JToken.ReadFromAsync(new JsonTextReader(reader));
                }
            }
            catch (Exception)
            {
                database = JObject.Parse("{'person':[],'indexTracker': 0}");

            }

            return database;
        }

    }
}

