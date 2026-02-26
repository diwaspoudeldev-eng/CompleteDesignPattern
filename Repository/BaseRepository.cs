using InterfaceDAL;
using System.Collections.Generic;

namespace Repository
{
    // A base class abstracting the repeating steps for ADO/Dapper/EF
    // This perfectly sets up the Template Method Design Pattern.
    // We define the skeleton of the algorithm (e.g., Save, Add, Update) and defer the specific DB execution to the subclasses.
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected string ConnectionString { get; private set; }

        public BaseRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        // These are the primitive operations that subclasses MUST implement
        protected abstract void ExecuteAdd(T entity);
        protected abstract void ExecuteUpdate(T entity);
        protected abstract void ExecuteDelete(T entity);
        protected abstract T ExecuteGetById(int id);
        protected abstract IEnumerable<T> ExecuteGetAll();
        protected abstract void ExecuteSave();

        // The Template Methods - providing the skeleton
        public void Add(T entity)
        {
            // E.g., validation or logging can happen here in the template
            ExecuteAdd(entity);
        }

        public void Update(T entity)
        {
            ExecuteUpdate(entity);
        }

        public void Delete(T entity)
        {
            ExecuteDelete(entity);
        }

        public T GetById(int id)
        {
            return ExecuteGetById(id);
        }

        public IEnumerable<T> GetAll()
        {
            return ExecuteGetAll();
        }

        public void Save()
        {
            ExecuteSave();
        }
    }
}
