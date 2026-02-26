using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repository
{
    public class AdoRepository<T> : BaseRepository<T> where T : class
    {
        public AdoRepository(string connectionString) : base(connectionString)
        {
        }

        protected override void ExecuteAdd(T entity)
        {
            // ADO.NET specific implementation (e.g., SqlCommand, SqlConnection)
            System.Console.WriteLine($"Adding {typeof(T).Name} using ADO.NET");
            
            if (entity is InterfaceLayer.ICustomer customer)
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    var cmd = new SqlCommand("INSERT INTO Customers (CustomerName, PhoneNumber, BillAmount, BillDate, Address) VALUES (@CustomerName, @PhoneNumber, @BillAmount, @BillDate, @Address)", connection);
                    cmd.Parameters.AddWithValue("@CustomerName", customer.CustomerName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@BillAmount", customer.BillAmount ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@BillDate", customer.BillDate ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", customer.Address ?? (object)DBNull.Value);
                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected override void ExecuteDelete(T entity)
        {
            // ADO.NET specific implementation
            System.Console.WriteLine($"Deleting {typeof(T).Name} using ADO.NET");
        }

        protected override IEnumerable<T> ExecuteGetAll()
        {
            // ADO.NET specific implementation
            System.Console.WriteLine($"Getting all {typeof(T).Name}s using ADO.NET");
            return new List<T>();
        }

        protected override T ExecuteGetById(int id)
        {
             // ADO.NET specific implementation
             System.Console.WriteLine($"Getting {typeof(T).Name} by ID using ADO.NET");
             return null;
        }

        protected override void ExecuteSave()
        {
             // ADO.NET specific implementation
             System.Console.WriteLine("Saving specific to ADO.NET");
        }

        protected override void ExecuteUpdate(T entity)
        {
             // ADO.NET specific implementation
             System.Console.WriteLine($"Updating {typeof(T).Name} using ADO.NET");
        }
    }
}
