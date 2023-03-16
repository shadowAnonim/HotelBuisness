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
        public string StandartPrice { get; set; } = "Нет данных";
        public string LuxPrice { get; set; } = "Нет данных";
        public string ApartmentPrice { get; set; } = "Нет данных";
    }
}
