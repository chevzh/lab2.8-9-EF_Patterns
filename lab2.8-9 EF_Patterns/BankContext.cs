using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2._8_9_EF_Patterns
{
    class BankContext : DbContext
    {
        public BankContext()
       : base("DbConnection")
        { }

        public DbSet<Investor> Investors { get; set; }
        public DbSet<Investment> Investments { get; set; }

    }
}
