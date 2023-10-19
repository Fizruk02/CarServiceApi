using CarServiceApi.Data;
using CarServiceApi.Models;

namespace CarServiceApi.Services
{
    public class OrderService
    {
        private readonly DataProvider _dataProvider;
        private readonly ClientService _clientService;
        private readonly CarService _carService;
        public OrderService(DataProvider dataProvider, CarService carService, ClientService clientService)
        {
            _clientService = clientService;
            _carService = carService;
            _dataProvider = dataProvider;
        }
        public Dictionary<int, Order> GetAll()
        {
            return _dataProvider.Orders;
        }
        public Order GetById(int id)
        {
            if (!_dataProvider.Orders.ContainsKey(id))
            {
                throw new Exception("Order does not exist!");
            }
            return _dataProvider.Orders[id];
        }
        public Order Create(Order order)
        {
            _dataProvider.Orders.Add(_dataProvider.Orders.Keys.Count, order);
            return order;
        }

        public bool Delete(int id)
        {
            return _dataProvider.Orders.Remove(id);
        }
        public Order Update(int id, Order order)
        {
            _dataProvider.Orders[id] = order;
            return order;
        }
    }
}