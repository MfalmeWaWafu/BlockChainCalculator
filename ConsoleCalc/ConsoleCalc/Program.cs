﻿using System;
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
            Console.WriteLine("Введите операцию:\nSum - Сумма\nSub - Разность\nMul - Умножение\nDiv - Деление\n");
            string op = Console.ReadLine();
            string first = args[0];
            string second = args[1];
            double firstn, secondn, result = 0;
            if ((Double.TryParse(first, out firstn)) && (Double.TryParse(second, out secondn)))
            {
                switch (op)
                {
                    case ("Sum"):
                        {
                            result = Calc.Sum(firstn, secondn);
                            break;
                        }
                    case ("Sub"):
                        {
                            result = Calc.Sub(firstn, secondn);
                            break;
                        }
                    case ("Mul"):
                        {
                            result = Calc.Multiplication(firstn, secondn);
                            break;
                        }
                    case ("Div"):
                        {
                            result = Calc.Division(firstn, secondn);
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Неизвестная операция");
                            break;
                        }
                }
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Неверные аргументы");
            }
            Console.ReadKey();
            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine("Калькулятор");
            //Console.ResetColor();
            //var operation = args[0];
            //if (operation == "sum")
            //{
            //    var number1 = Convert.ToInt32(args[1]);
            //    var number2 = Convert.ToInt32(args[2]);
            //    var res = number1 + number2;
            //    //Console.WriteLine($"sum(" + number1 + "," + number2 + ")=" + res);
            //    Console.WriteLine($"sum({number1},{number2}) = {res}");
            //}
            //else
            //{
            //    Console.WriteLine("Error");
            //}
            //Console.ReadKey();
        }
    }
}