using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalc
{
    public static class Calc
    {
        static public double Sub(double x, double y)
        {
            return x - y;
        }
        static public double Sum(double x, double y)
        {
            return x + y;
        }
        static public double Multiplication(double x, double y)
        {
            return x * y;
        }
        static public double Division(double x, double y)
        {
            return x / y;
        }
    }
}
