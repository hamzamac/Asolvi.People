using System;
using System.Collections.Generic;
using System.Text;

namespace JSONDb.Test
{
    class ItemDbContext: DBContext
    {
        public ItemDbContext(): base("jasonFileLocation")
        {

        }
        //ItemDbContect
        public Dataset<Item> Items { get; set; }

        public void Test()
        {
            Items.GetAll();
        }
    }
}
