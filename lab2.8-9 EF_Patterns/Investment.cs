using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2._8_9_EF_Patterns
{
    class Investment
    {
        public int InvestmentId { get; set; }
        public string Name { get; set; }
        public float YearPercent { get; set; }
        public float InvestmentSum { get; set; }
        public float InvestmentPeriod { get; set; }
        public DateTime DateOfInvestment { get; set; }

        public ICollection<Investor> Investors { get; set; }

        public Investment()
        {
            Investors = new List<Investor>();
        }


    }
}
