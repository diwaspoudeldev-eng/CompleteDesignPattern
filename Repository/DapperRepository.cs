using System.Collections.Generic;

namespace Repository
{
    public class DapperRepository<T> : BaseRepository<T> where T : class
    {
        public DapperRepository(string connectionString) : base(connectionString)
        {
        }

        protected override void ExecuteAdd(T entity)
        {
            // Dapper specific implementation (e.g., Connection.Execute)
            System.Console.WriteLine($"Adding {typeof(T).Name} using Dapper");
        }

        protected override void ExecuteDelete(T entity)
        {
             // Dapper specific implementation
             System.Console.WriteLine($"Deleting {typeof(T).Name} using Dapper");
        }

        protected override IEnumerable<T> ExecuteGetAll()
        {
             // Dapper specific implementation
             System.Console.WriteLine($"Getting all {typeof(T).Name}s using Dapper");
             return new List<T>();
        }

        protected override T ExecuteGetById(int id)
        {
              // Dapper specific implementation
             System.Console.WriteLine($"Getting {typeof(T).Name} by ID using Dapper");
             return null;
        }

        protected override void ExecuteSave()
        {
             // Dapper specific implementation
             System.Console.WriteLine("Saving specific to Dapper");
        }

        protected override void ExecuteUpdate(T entity)
        {
             // Dapper specific implementation
             System.Console.WriteLine($"Updating {typeof(T).Name} using Dapper");
        }
    }
}
