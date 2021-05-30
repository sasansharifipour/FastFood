using DAO;
using Domain.BaseClasses;

namespace Service
{
    public interface ICustomerService
    {
        bool add(Customer customer);
    }

    public class CustomerService : ICustomerService
    {
        private ICustomerDAO _customer_dao; 

        public CustomerService(ICustomerDAO customer_dao)
        {
            _customer_dao = customer_dao;
        }

        public bool add(Customer customer)
        {
            return _customer_dao.Add(customer);
        }
    }
}
