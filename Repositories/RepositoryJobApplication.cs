using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryJobApplication : Repository<Entity.JobApplication>, IRepositoryJobApplication
    {
        public RepositoryJobApplication(DBContext dbContext)
            : base(dbContext)
        {
        }
    }



}
