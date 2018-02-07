using ItUniver.Calc.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google.Calc.Finance
{
    public class CreditOperation : IOperation
    {
        public int argCount
        {
            get { return 2; }
        }

        public string Name => "Credit";

        public double Exec(double[] args)
        {
            return args.Aggregate((x, y) => x / y * 0.9);
        }
    }
}
