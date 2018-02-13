using Ituniver.Calc.DB.Models;
using Ituniver.Calc.DB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItUniver.Calc.WinFormApp
{
    public static class MyHelper
    {
        //private static IHistoryRepository History = new MemoryRepository();
        //private static IHistoryRepository History = new DBRepository();
        private static IBaseRepository<HistoryItem> History = new BaseRepository<HistoryItem>("History");

        public static void AddToHistoty(string oper, double[] args, double result)
        {
            var item = new HistoryItem();
            item.Args = string.Join(" ", args);
            item.ExecDate = DateTime.Now;
            item.Operation = oper;
            item.Result = result;
            History.Save(item);
        }
        public static string[] GetAll()
        {
            return History.GetAll().Select(hi=>$"{hi.Operation}({hi.Args}) = {hi.Result} / {hi.ExecDate}").ToArray();
        }
    }
}
