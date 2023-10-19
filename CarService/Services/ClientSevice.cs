using CarServiceApi.Data;
using CarServiceApi.Models;

namespace CarServiceApi.Services
{
    public class ClientService
    {
        private readonly DataProvider _dataProvider;
        private readonly CarService _carService;

        public ClientService(DataProvider dataProvider, CarService carService)
        {
            _dataProvider = dataProvider;
            _carService = carService;
        }
        public Dictionary<int, Client> GetAll()
        {
            return _dataProvider.Clients;
        }
        public Client GetById(int id)
        {
            if (!_dataProvider.Clients.ContainsKey(id))
            {
                throw new Exception("Client does not exist!");
            }
            return _dataProvider.Clients[id];
        }
        public Client Create(Client client)
        {
            _dataProvider.Clients.Add(_dataProvider.Clients.Keys.Count, client);
            return client;
        }

        public bool Delete(int id)
        {
            return _dataProvider.Clients.Remove(id);
        }
        public Client Update(int id, Client client)
        {
            _dataProvider.Clients[id] = client;
            return client;
        }
        public Dictionary<int, Car> GetCarsByClient(int clientId)
        {
            return GetOrdersByClient(clientId).Select(o => o.Value.CarId).ToDictionary(x => x, y => _carService.GetById(y));
        }
        public Dictionary<int, Order> GetOrdersByClient(int clientId)
        {
            return _dataProvider.Orders.Where(o => o.Value.ClientId == clientId).ToDictionary(x => x.Key, y => y.Value);
        }
    }
}