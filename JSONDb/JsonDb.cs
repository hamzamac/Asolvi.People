using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;


namespace JSONDb.Test
{
    //public class JsonDb<T>
    //{
    //    private JObject _database;
    //    private JArray _table;
    //    private string _jsonFilePath;
    //    private int _rowId;

    //    public JsonDb(/*IConfiguration configuration*/)
    //    {
    //        // _jsonFilePath = configuration.GetConnectionString("JSONFilePath");
    //        _database = this.Fetch().GetAwaiter().GetResult();
    //        _table = (JArray)_dataset["person"];
    //        _rowId = (int)(JValue)_dataset["indexTracker"];
    //    }

    //    // Read data from dataset
    //    private async Task<JObject> Fetch()
    //    {
    //        JObject dataset;
    //        try
    //        {
    //            if (!File.Exists(_jsonFilePath))
    //            {
    //                //initialize a database file
    //                File.WriteAllText(_jsonFilePath, "{'person':[],'indexTracker': 0}");
    //            }
    //            using (StreamReader reader = File.OpenText(_jsonFilePath))
    //            {
    //                dataset = (JObject)await JToken.ReadFromAsync(new JsonTextReader(reader));
    //            }
    //        }
    //        catch (Exception)
    //        {
    //            dataset = JObject.Parse("{'person':[],'indexTracker': 0}");

    //        }

    //        return dataset;
    //    }

    //    public void SaveChanges()
    //    {
    //        //save changes to json file on disk
    //        JsonSerializer serializer = new JsonSerializer();
    //        serializer.NullValueHandling = NullValueHandling.Ignore;
    //        _dataset["indexTracker"] = _rowId;
    //        using (StreamWriter sw = new StreamWriter(_jsonFilePath))
    //        using (JsonWriter writer = new JsonTextWriter(sw))
    //        {
    //            serializer.Serialize(writer, _dataset);
    //        }
    //    }
    //}

}
