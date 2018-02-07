using ConsoleCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calc();
            string[] param = new string[10];
            var operations = calc.GetOperNames();
            if (args.Length == 0)
            {
                Console.WriteLine("Введите операцию");
                foreach (var item in operations)
                {
                    Console.WriteLine(item);
                }

                string oper = Console.ReadLine();
                Console.WriteLine("Введите аргументы функции:");
                string numbers = Console.ReadLine();
                string[] ar = numbers.Split(',');
                Array.ConstrainedCopy(ar,0,param,2,ar.Length);
                param[0] = oper;
                param[1] = ar.Length.ToString();
            }
            Calculation(param);
            Console.ReadKey();
        }

        static void Calculation(string[] array)
        {
            var calc = new Calc();
            double result = 0;
            double[] mas = new double[10];
            int count = Convert.ToInt32(array[1]) + 2;
            for (int i=2; i<count;i++)
            {
                if (!Double.TryParse(array[i], out mas[i-2]))
                {
                    Console.WriteLine("Один или несколько аргументов имеют неверный формат");
                    break;
                }
            }
            result = calc.Exec(array[0], mas);
            //Console.WriteLine($"{array[0]}({firstnum},{secondnum}) = {result}");
            Console.WriteLine(result);
        }
    }
}