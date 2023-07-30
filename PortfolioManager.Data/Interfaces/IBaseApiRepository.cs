using PortfolioManager.Data.Models;
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
        void Delete(T entity);
        T? Update(T entity);
        T? Insert(T entity);
        bool Exists(string Name, DateTime date);
        IEnumerable<T> GetByName(string name);
        T? Get(string Name,DateTime date);
    }
}
