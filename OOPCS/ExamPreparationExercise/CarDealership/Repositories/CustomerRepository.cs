using CarDealership.Models.Contracts;
using CarDealership.Repositories.Contracts;

namespace CarDealership.Repositories
{
    public class CustomerRepository : IRepository<ICustomer>
    {
        private List<ICustomer> customers = new List<ICustomer>();

        public IReadOnlyCollection<ICustomer> Models => customers.AsReadOnly();

        public void Add(ICustomer customer)
        {
            customers.Add(customer);
        }

        public bool Exists(string customer)
        {
            return customers.Any(c => c.Name == customer);
        }

        public ICustomer Get(string customer)
        {
            return customers.FirstOrDefault(c => c.Name == customer);
        }

        public bool Remove(string customer)
        {
            return customers.Remove(Get(customer));
        }
    }
}
