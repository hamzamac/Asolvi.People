using JsonFileDB;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asolvi.People.Models
{
    public class ApplicationDBContext : DBContext
    { 
        public ApplicationDBContext(IConfiguration configuration) 
            :base(configuration.GetConnectionString("JSONFilePath")) //can be provided as string literal
        {
            Persons = new Dataset<Person>(_database);
            Locations = new Dataset<Location>(_database);
        }

        //declare all table intstances
        public Dataset<Person> Persons { get; set; }
        public Dataset<Location> Locations { get; set; }

    }
}
