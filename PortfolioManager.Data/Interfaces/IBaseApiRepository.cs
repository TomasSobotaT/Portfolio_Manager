using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManager.Data.Interfaces
{
    public interface IBaseApiRepository<T> where T : class
    {
        IEnumerable<T> GetAll();    
        T? Get(string Name,DateTime date);
        void Delete(string name, DateTime date);
        void Update(T entity);
        void Insert(T entity);
        bool Exists(string Name, DateTime date);



    }
}
