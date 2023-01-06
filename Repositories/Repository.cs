using Entity;
namespace Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DBContext context;
        public Repository(DBContext context)
        {

            this.context = context;

        }
        public IEnumerable<T> GetAll()
        {
            context.Set<T>();
            return context.Set<T>();
        }
        public void Insert(T entity)
        {
            context.Set<T>().Add(entity);
        }
    }
}
