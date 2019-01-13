using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2._8_9_EF_Patterns
{
    class Investor
    {
        public int InvestorId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }


        public ICollection<Investment> Investments { get; set; }

        public Investor()
        {
            Investments = new List<Investment>();
        }

    }
}
