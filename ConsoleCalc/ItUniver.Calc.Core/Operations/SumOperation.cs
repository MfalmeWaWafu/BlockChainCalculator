using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItUniver.Calc.Core.Interfaces;

namespace ItUniver.Calc.Core.Operations
{
    public class SumOperation : SuperOperation
    {
        public override string Description => "Арифметическое действие, посредством которого из двух или нескольких чисел получают новое, содержащее столько единиц, сколько было во всех данных числах вместе.";
       
        public override string Name => "Sum";

        public override double Exec(double[] args)
        {
            return args.Sum();
        }
    }
}
