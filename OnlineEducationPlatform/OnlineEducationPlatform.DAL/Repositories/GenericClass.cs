using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.DbHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories
{
    public class GenericClass<T> : IGenericRepository<T> where T : class
    {
        private readonly EducationPlatformContext _Context;
        private readonly DbSet<T>_dbSet;


        public GenericClass(EducationPlatformContext Context)
        {
            _Context = Context;
            _dbSet = _Context.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

       

       

        public void SaveChange()
        {
            _Context.SaveChanges();
        }

        public void Update(T entity)
        {
           
        }
    }
}
