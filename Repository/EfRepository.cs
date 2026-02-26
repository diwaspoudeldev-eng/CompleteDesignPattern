using System.Collections.Generic;

namespace Repository
{
    public class EfRepository<T> : BaseRepository<T> where T : class
    {
        public EfRepository(string connectionString) : base(connectionString)
        {
        }

        protected override void ExecuteAdd(T entity)
        {
            // Entity Framework specific implementation (e.g., DbContext.Set<T>().Add)
            System.Console.WriteLine($"Adding {typeof(T).Name} using Entity Framework");
        }

        protected override void ExecuteDelete(T entity)
        {
             // Entity Framework specific implementation
             System.Console.WriteLine($"Deleting {typeof(T).Name} using Entity Framework");
        }

        protected override IEnumerable<T> ExecuteGetAll()
        {
             // Entity Framework specific implementation
             System.Console.WriteLine($"Getting all {typeof(T).Name}s using Entity Framework");
             return new List<T>();
        }

        protected override T ExecuteGetById(int id)
        {
              // Entity Framework specific implementation
             System.Console.WriteLine($"Getting {typeof(T).Name} by ID using Entity Framework");
             return null;
        }

        protected override void ExecuteSave()
        {
             // Entity Framework specific implementation (e.g., DbContext.SaveChanges())
             System.Console.WriteLine("Saving specific to Entity Framework");
        }

        protected override void ExecuteUpdate(T entity)
        {
             // Entity Framework specific implementation
             System.Console.WriteLine($"Updating {typeof(T).Name} using Entity Framework");
        }
    }
}
