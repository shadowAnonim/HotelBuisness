using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Data
{
    internal class Night
    {
        public Night(Hotel hotel, Category category, int nights, decimal sum)
        {
            Hotel = hotel;
            Category = category;
            Nights = nights;
            Sum = sum;
        }

        public Hotel Hotel { get; set; }
        public Category Category { get; set; }
        public int Nights { get; set; }
        public decimal Sum { get; set; }
    }
}
