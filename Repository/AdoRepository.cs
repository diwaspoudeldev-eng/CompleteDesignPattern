using System.Collections.Generic;
using System.Data.SqlClient;
using CustomerFactory;

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
                    var cmd = new SqlCommand("INSERT INTO Customers (CustomerName, PhoneNumber, BillAmount, BillDate, Address, CustomerType) VALUES (@CustomerName, @PhoneNumber, @BillAmount, @BillDate, @Address, @CustomerType)", connection);
                    cmd.Parameters.AddWithValue("@CustomerName", customer.CustomerName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@BillAmount", customer.BillAmount ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@BillDate", customer.BillDate ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", customer.Address ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CustomerType", customer.GetType().Name ?? (object)DBNull.Value);
                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected override void ExecuteDelete(T entity)
        {
            if (entity is InterfaceLayer.ICustomer customer)
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    var cmd = new SqlCommand("DELETE FROM Customers WHERE CustomerName = @CustomerName", connection);
                    cmd.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected override IEnumerable<T> ExecuteGetAll()
        {
             // ADO.NET specific implementation
             System.Console.WriteLine($"Getting all {typeof(T).Name}s using ADO.NET from Database");
             
             var list = new List<T>();
             if (typeof(T) == typeof(InterfaceLayer.ICustomer))
             {
                 using (var connection = new SqlConnection(ConnectionString))
                 {
                     connection.Open();
                     var cmd = new SqlCommand("SELECT CustomerID, CustomerName, PhoneNumber, BillAmount, BillDate, Address, CustomerType FROM Customers", connection);
                     using (var reader = cmd.ExecuteReader())
                     {
                         while (reader.Read())
                         {
                             // Defensive null check for CustomerType
                             string type = reader["CustomerType"] != DBNull.Value ? reader["CustomerType"].ToString() : "Customer";
                             if (string.IsNullOrEmpty(type)) type = "Customer";

                             var customer = CustomerFactory.Factory.Create(type); 
                             customer.Id = reader["CustomerID"] != DBNull.Value ? Convert.ToInt32(reader["CustomerID"]) : 0;
                             customer.CustomerName = reader["CustomerName"] != DBNull.Value ? reader["CustomerName"].ToString() : "";
                             customer.PhoneNumber = reader["PhoneNumber"] != DBNull.Value ? reader["PhoneNumber"].ToString() : "";
                             customer.BillAmount = reader["BillAmount"] != DBNull.Value ? Convert.ToDecimal(reader["BillAmount"]) : 0;
                             customer.BillDate = reader["BillDate"] != DBNull.Value ? Convert.ToDateTime(reader["BillDate"]) : null;
                             customer.Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : "";
                             
                             list.Add((T)customer);
                         }
                     }
                 }
             }
             return list;
        }

        protected override T ExecuteGetById(int id)
        {
             // Assuming the table has an auto-incrementing 'Id' column
             if (typeof(T) == typeof(InterfaceLayer.ICustomer))
             {
                 using (var connection = new SqlConnection(ConnectionString))
                 {
                     connection.Open();
                     var cmd = new SqlCommand("SELECT CustomerName, PhoneNumber, BillAmount, BillDate, Address FROM Customers WHERE Id = @Id", connection);
                     cmd.Parameters.AddWithValue("@CustomerID", id);
                     using (var reader = cmd.ExecuteReader())
                     {
                         if (reader.Read())
                         {
                             var customer = CustomerFactory.Factory.Create("Customer"); 
                             customer.CustomerName = reader["CustomerName"]?.ToString();
                             customer.PhoneNumber = reader["PhoneNumber"]?.ToString();
                             customer.BillAmount = reader["BillAmount"] != DBNull.Value ? Convert.ToDecimal(reader["BillAmount"]) : 0;
                             customer.BillDate = reader["BillDate"] != DBNull.Value ? Convert.ToDateTime(reader["BillDate"]) : null;
                             customer.Address = reader["Address"]?.ToString();
                             return (T)customer;
                         }
                     }
                 }
             }
             return null;
        }

        protected override void ExecuteSave()
        {
             // ADO.NET specific implementation
             System.Console.WriteLine("Saving specific to ADO.NET");
        }

        protected override void ExecuteUpdate(T entity)
        {
            if (entity is InterfaceLayer.ICustomer customer)
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    var cmd = new SqlCommand("UPDATE Customers SET PhoneNumber = @PhoneNumber, BillAmount = @BillAmount, BillDate = @BillDate, Address = @Address, CustomerType = @CustomerType WHERE CustomerName = @CustomerName", connection);
                    cmd.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@BillAmount", customer.BillAmount ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@BillDate", customer.BillDate ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", customer.Address ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CustomerType", customer.GetType().Name ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
