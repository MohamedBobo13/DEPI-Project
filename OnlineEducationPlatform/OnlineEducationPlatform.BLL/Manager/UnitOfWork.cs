using OnlineEducationPlatform.DAL.Data.DbHelper;
using OnlineEducationPlatform.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager
{
    public class UnitOfWork : IunitOfWork
    {
        private readonly EducationPlatformContext educationPlatformContext;

        public UnitOfWork(EducationPlatformContext educationPlatformContext)
        {
            this.educationPlatformContext = educationPlatformContext;
        }
        public async Task<int> CompleteAsync()
        {
           return await educationPlatformContext.SaveChangesAsync();
        }

        public void Dispose()
        {
          educationPlatformContext.Dispose();
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            throw new NotImplementedException();
        }
    }
}
