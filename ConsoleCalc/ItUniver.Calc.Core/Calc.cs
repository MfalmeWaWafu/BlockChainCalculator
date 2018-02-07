using ItUniver.Calc.Core.Interfaces;
using ItUniver.Calc.Core.Operations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalc
{
    public class Calc
    {
        private IList<IOperation> operations { get; set; }

        public void LoadOperation(Assembly assembly)
        {
            var types = assembly.GetTypes();
            var typeOperation = typeof(IOperation);
            foreach (var item in types.Where(t=>!t.IsAbstract && !t.IsInterface))
            {
                var interfaces = item.GetInterfaces();

                var isOperation = interfaces.Any(it => it == typeOperation);
                if (isOperation)
                {
                    //Создаем экземпрляр объекта
                    var obj = Activator.CreateInstance(item);
                    //пытаемся превратить его в операцию
                    var operation = (IOperation)obj;
                    //если удалось
                    if (operation != null)
                    {
                        //Добавляем в список операций
                        operations.Add(operation);
                    }
                }
            }
        }

        public Calc()
        {
            operations = new List<IOperation>();
            //var assembly = Assembly.GetExecutingAssembly();
            //Загружаем свои библиотеки
            LoadOperation(Assembly.GetExecutingAssembly());

            //Загружаем сторонние библиотеки
            var extensionsDir = Environment.CurrentDirectory;
            var files = Directory.GetFiles(extensionsDir + "Extensions", "*.dll");
            foreach (var item in files)
            {
                //var assembly = Assembly.LoadFile(@"C:\It-Univer\BlockChainCalculator\Google.Calc.Finance\Google.Calc.Finance\bin\Debug\Google.Calc.Finance.dll");
                LoadOperation(Assembly.LoadFile(item));
            }

            
            
        }

        /// <summary>
        /// Получить список имен операций
        /// </summary>
        /// <returns></returns>
        public string[] GetOperNames()
        {
            return operations.Select(o => o.Name).ToArray(); ;
        }

        public double Exec(string oper, double[] args)
        {

            //Найти операцию в списке
            var operation = operations.FirstOrDefault(o => o.Name == oper);

            //Если не найдено - возвращаем ошибку
            if (operation == null)
                return double.NaN;
            //если нашли

            //передаем ей аргументы и вычисляем результат
            var result = operation.Exec(args);
            //Возвращаем результат
            return result;
        }

        public double Sub(double x, double y)
        {
            var oper = new SubOperation();
            var result = oper.Exec(new[] { x, y });
            return result;
        }
        public double Sum(double x, double y)
        {
            var oper = new SumOperation();
            var result = oper.Exec(new[] { x, y });
            return result;
        }
        public double Multiplication(double x, double y)
        {
            var oper = new MulOperation();
            var result = oper.Exec(new[] { x, y });
            return result;
        }
        public double Division(double x, double y)
        {
            var oper = new DivOperation();
            var result = oper.Exec(new[] { x, y });
            return result;
        }
    }
}
