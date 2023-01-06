using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        readonly DBContext _dbContext;
        public IRepositoryJobApplication JobApplication { get; set; }
        public UnitOfWork(DBContext dbContext)
        {
            _dbContext = dbContext;
            JobApplication = new RepositoryJobApplication(dbContext);

        }

        

        public void Complete()
        {
            _dbContext.SaveChanges();

        }

        public void Dispose()
        {

            _dbContext.Dispose();
        }

    }
}
