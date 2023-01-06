namespace Repositories
{
    public interface IRepository<T> where T : class
    {
        // This is the default methods,  need
        IEnumerable<T> GetAll();
        void Insert(T entity);
    }
}
