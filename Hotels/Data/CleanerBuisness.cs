using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Data
{
    class CleanerBuisness
    {
        public CleanerBuisness  (Worker name, string ready = "0", string now = "0", string cleaned = "0")
        {
            Name = name;
            Ready = ready;
            Now = now;
            Cleaned = cleaned;
        }

        public Worker Name { get; set; }

        public string Ready { get; set; }

        public string Now { get; set; }

        public string Cleaned { get; set; }
    }
}
