using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDataDragons
{
    public class Loan 
    {
        private float BankLoan { get; set; }
        public float MaximumLoan { get; set; }
        public Loan(float bankloan)
        {
            BankLoan = bankloan;
        }


    }
}
