using Ituniver.Calc.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ituniver.Calc.DB.Repositories
{
    public interface IHistoryRepository : IBaseRepository<IHistoryItem>
    {
        //IHistoryItem GetByOperatin(long Id);
    }

    public interface IOperationRepository : IBaseRepository<Operation>
    {
    }
}
