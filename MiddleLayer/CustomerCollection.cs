using System.Collections;
using InterfaceLayer;

namespace MiddleLayer
{
    public class CustomerCollection : IEnumerable<ICustomer>
    {
        private List<ICustomer> _customers = new List<ICustomer>();

        public void Add(ICustomer customer)
        {
            _customers.Add(customer);
        }

        public void Clear()
        {
            _customers.Clear();
        }

        public IEnumerator<ICustomer> GetEnumerator()
        {
            // The magic is here. Yield return provides the iterator functionality.
            foreach (var customer in _customers)
            {
                yield return customer;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
