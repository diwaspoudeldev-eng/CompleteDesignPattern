using System.Collections.Generic;
using System.Linq;
using CustomerFactory;

namespace Repository
{
    public class EfRepository<T> : BaseRepository<T> where T : class
    {
        public EfRepository(string connectionString) : base(connectionString)
        {
        }

        protected override void ExecuteAdd(T entity)
        {
            if (entity is InterfaceLayer.ICustomer customer)
            {
                using (var context = new CustomerDbContext(ConnectionString))
                {
                    var entityToStore = new CustomerEntity
                    {
                        CustomerName = customer.CustomerName,
                        PhoneNumber = customer.PhoneNumber,
                        BillAmount = customer.BillAmount,
                        BillDate = customer.BillDate,
                        Address = customer.Address,
                        CustomerType = customer.GetType().Name // Storing the concrete class name as discriminator
                    };
                    context.Set<CustomerEntity>().Add(entityToStore);
                    context.SaveChanges();
                    System.Console.WriteLine($"Added {typeof(T).Name} using EF Core with Internal Entity mapping");
                }
            }
        }

        protected override void ExecuteDelete(T entity)
        {
            if (entity is InterfaceLayer.ICustomer customer)
            {
                using (var context = new CustomerDbContext(ConnectionString))
                {
                    var dbEntity = context.Set<CustomerEntity>().Find(customer.CustomerName);
                    if (dbEntity != null)
                    {
                        context.Set<CustomerEntity>().Remove(dbEntity);
                        context.SaveChanges();
                    }
                }
            }
        }

        protected override IEnumerable<T> ExecuteGetAll()
        {
            System.Console.WriteLine($"Getting all {typeof(T).Name}s using EF Core with Internal Entity mapping");

            using (var context = new CustomerDbContext(ConnectionString))
            {
                var dbEntities = context.Set<CustomerEntity>().ToList();
                var list = new List<T>();

                foreach (var dbEntity in dbEntities)
                {
                    // Defensive null check for CustomerType
                    string type = dbEntity.CustomerType ?? "Customer";
                    if (string.IsNullOrWhiteSpace(type)) type = "Customer";

                    // Use the Factory to create the correct domain object from MiddleLayer (via interface)
                    var domainObj = CustomerFactory.Factory.Create(type);
                    domainObj.Id = dbEntity.Id;
                    domainObj.CustomerName = dbEntity.CustomerName ?? "";
                    domainObj.PhoneNumber = dbEntity.PhoneNumber ?? "";
                    domainObj.BillAmount = dbEntity.BillAmount ?? 0;
                    domainObj.BillDate = dbEntity.BillDate;
                    domainObj.Address = dbEntity.Address ?? "";

                    list.Add((T)domainObj);
                }

                return list;
            }
        }

        protected override T ExecuteGetById(int id)
        {
            // Implementation would depend on how we map the ID, 
            // for now, we follow the same pattern if needed.
            return null;
        }

        protected override void ExecuteSave()
        {
            System.Console.WriteLine("Executing EF Core Save (Handled in methods)");
        }

        protected override void ExecuteUpdate(T entity)
        {
            if (entity is InterfaceLayer.ICustomer customer)
            {
                using (var context = new CustomerDbContext(ConnectionString))
                {
                    var dbEntity = context.Set<CustomerEntity>().Find(customer.CustomerName);
                    if (dbEntity != null)
                    {
                        dbEntity.PhoneNumber = customer.PhoneNumber;
                        dbEntity.BillAmount = customer.BillAmount;
                        dbEntity.BillDate = customer.BillDate;
                        dbEntity.Address = customer.Address;
                        dbEntity.CustomerType = customer.GetType().Name;
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
