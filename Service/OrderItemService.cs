using DAO;
using Domain.BaseClasses;

namespace Service
{
    public interface IOrderItemService
    {
        bool add(OrderItem data);
    }

    public class OrderItemService : IOrderItemService
    {
        private IOrderItemDAO _dao; 

        public OrderItemService(IOrderItemDAO dao)
        {
            _dao = dao;
        }

        public bool add(OrderItem data)
        {
            return _dao.Add(data);
        }
    }
}
