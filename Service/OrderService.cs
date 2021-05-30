using DAO;
using Domain.BaseClasses;

namespace Service
{
    public interface IOrderService
    {
        bool add(Order data);
    }

    public class OrderService : IOrderService
    {
        private IOrderDAO _dao; 

        public OrderService(IOrderDAO dao)
        {
            _dao = dao;
        }

        public bool add(Order data)
        {
            return _dao.Add(data);
        }
    }
}
