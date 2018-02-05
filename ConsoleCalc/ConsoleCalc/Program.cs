using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Калькулятор");
            Console.ResetColor();
            var operation = args[0];
            if (operation == "sum")
            {
                var number1 = Convert.ToInt32(args[1]);
                var number2 = Convert.ToInt32(args[2]);
                var res = number1 + number2;
                //Console.WriteLine($"sum(" + number1 + "," + number2 + ")=" + res);
                Console.WriteLine($"sum({number1},{number2}) = {res}");
            }
            else
            {
                Console.WriteLine("Error");
            }
            Console.ReadKey();
        }
    }
}