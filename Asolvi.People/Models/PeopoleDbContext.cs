using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JSONDb;
using Microsoft.Extensions.Configuration;

namespace Asolvi.People.Models
{
    public class PeopoleDbContext: DBContext
    {
        public PeopoleDbContext(IConfiguration configuration) :base(configuration.GetConnectionString("JSONFilePath"))
        {
            Persons = new Dataset<Person>(database);
        }

        public Dataset<Person> Persons { get; set; }
    }
}
