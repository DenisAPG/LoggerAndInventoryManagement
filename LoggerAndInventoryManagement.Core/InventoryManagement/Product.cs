using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LoggerAndInventoryManagement.Core.InventoryManagement
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock {  get; set; }

        public override String ToString()
        {
            return JsonSerializer.Serialize(this);
        }

    }
}
