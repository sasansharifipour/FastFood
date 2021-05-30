using DAO;
using Domain.BaseClasses;

namespace Service
{
    public interface IFoodService
    {
        bool add(Food data);
    }

    public class FoodService : IFoodService
    {
        private IFoodDAO _dao; 

        public FoodService(IFoodDAO dao)
        {
            _dao = dao;
        }

        public bool add(Food data)
        {
            return _dao.Add(data);
        }
    }
}
