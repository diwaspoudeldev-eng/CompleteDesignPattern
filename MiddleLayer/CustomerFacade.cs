using System;
using System.Collections.Generic;
using System.Linq;
using InterfaceLayer;
using InterfaceDAL;

namespace MiddleLayer
{
    public class CustomerFacade
    {
        private readonly IRepository<ICustomer> _adoRepository;
        private readonly IRepository<ICustomer> _efRepository;
        private readonly CustomerCollection _customersInMemory;
        private readonly Func<string, ICustomer> _customerFactory;

        public CustomerFacade(IRepository<ICustomer> adoRepository, IRepository<ICustomer> efRepository, Func<string, ICustomer> customerFactory)
        {
            _adoRepository = adoRepository;
            _efRepository = efRepository;
            _customerFactory = customerFactory;
            _customersInMemory = new CustomerCollection();
        }

        private IRepository<ICustomer> GetRepository(string dalType)
        {
            return dalType == "ADO" ? _adoRepository : _efRepository;
        }

        public void AddDirect(string customerType, int id, string name, string phone, decimal? amount, DateTime? date, string address, string dalType)
        {
            ICustomer customer = BuildCustomer(customerType, id, name, phone, amount, date, address);
            customer.Validate();
            GetRepository(dalType).Add(customer);
        }

        public void AddToMemory(string customerType, int id, string name, string phone, decimal? amount, DateTime? date, string address)
        {
            ICustomer customer = BuildCustomer(customerType, id, name, phone, amount, date, address);
            customer.Validate();
            _customersInMemory.Add(customer);
        }

        public void BatchSave(string dalType)
        {
            var repo = GetRepository(dalType);
            foreach (var customer in _customersInMemory)
            {
                repo.Add(customer);
            }
            _customersInMemory.Clear();
        }

        public List<ICustomer> GetCombinedData(string dalType)
        {
            var dbData = GetRepository(dalType).GetAll()?.ToList() ?? new List<ICustomer>();
            return dbData.Concat(_customersInMemory).ToList();
        }

        public ICustomer BuildCustomer(string type, int id, string name, string phone, decimal? amount, DateTime? date, string address)
        {
            // Using the delegate provided during construction to break circular dependency
            return new CustomerBuilder(_customerFactory(type))
                .WithId(id)
                .WithName(name)
                .WithPhone(phone)
                .WithBilling(amount, date)
                .WithAddress(address)
                .Build();
        }

        public ICustomer CloneCustomer(ICustomer source)
        {
            if (source == null) return null;
            ICustomer clone = source.Clone();
            clone.Id = 0;
            return clone;
        }

        public void AddToMemory(ICustomer customer)
        {
            if (customer != null)
                _customersInMemory.Add(customer);
        }

        public string GenerateCsvReport(IEnumerable<ICustomer> data)
        {
            IReportBuilder builder = new CsvReportBuilder();
            builder.AddHeader(new string[] { "ID", "Name", "Phone", "Amount", "Date", "Address" });
            
            foreach (var item in data)
            {
                builder.AddRow(new string[] {
                    item.Id.ToString(),
                    item.CustomerName ?? "",
                    item.PhoneNumber ?? "",
                    item.BillAmount.ToString() ?? "0",
                    item.BillDate?.ToShortDateString() ?? "",
                    item.Address ?? ""
                });
            }
            
            builder.AddFooter($"Total Records: {data.Count()}");
            return builder.GetReport();
        }
    }
}
