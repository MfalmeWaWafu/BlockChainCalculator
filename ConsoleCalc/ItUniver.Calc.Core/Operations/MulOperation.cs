using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItUniver.Calc.Core.Interfaces;

namespace ItUniver.Calc.Core.Operations
{
    public class MulOperation : IOperation
    {
        public int argCount
        {
            get { return 2; }
        }

        public string Name => "Mul";

        public double Exec(double[] args)
        {
            return args.Aggregate((x,y) => x * y);
        }
    }
}
