using Ituniver.Calc.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ituniver.Calc.DB.Repositories
{
    public interface IEntity
    {
        long Id { get; set; }
    }

    public interface IBaseRepository<T>
        where T : IEntity
    {
        IEnumerable<T> GetAll();

        T Find(long id);

        void Save(T item);

        void Delete(long id);    
    }
}
