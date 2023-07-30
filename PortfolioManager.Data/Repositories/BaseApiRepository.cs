using Microsoft.EntityFrameworkCore;
using PortfolioManager.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManager.Data.Repositories
{
    public class BaseApiRepository<T> : IBaseApiRepository<T> where T : class
    {
        protected readonly ApplicationDbContext applicationDbContext;
        protected readonly DbSet<T> dbSet;
        public BaseApiRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
            dbSet = applicationDbContext.Set<T>();
        }

        public virtual void Delete(string name, DateTime date)
        {
            T? entity = dbSet.Find(name, date);

            if (entity is null)
                return;

            try
            {
                dbSet.Remove(entity);
                applicationDbContext.SaveChanges();
            }


            catch
            {
                applicationDbContext.Entry(entity).State = EntityState.Unchanged;
                throw;
            }
        }

        public virtual bool Exists(string Name, DateTime date)
        {
            T? entity = dbSet.Find(Name, date);

            if (entity == null)
                return false;

            return true;
        }

        public virtual T? Get(string name, DateTime date)
        {
            T? entity = dbSet.Find(name,date);
            return entity;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual void Insert(T entity)
        {
            dbSet.Add(entity);
            applicationDbContext.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            dbSet.Update(entity);
            applicationDbContext.SaveChanges();
        }
    }
}