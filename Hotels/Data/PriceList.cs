using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Data
{
    internal class PriceList
    {
        public string Name { get; set; }
        public decimal StandartPrice { get; set; }
        public decimal LuxPrice { get; set; }
        public decimal ApartmentPrice { get; set; }
    }
}
