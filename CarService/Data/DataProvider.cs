using CarServiceApi.Models;
using System.Security.Claims;

namespace CarServiceApi.Data
{
    public class DataProvider
    {
        public Dictionary<int, Client> Clients { get; private set; }
        public Dictionary<int, Order> Orders { get; private set; }
        public Dictionary<int, Car> Cars { get; private set; }

        public DataProvider()
        {
            Clients = new Dictionary<int, Client>();
            Orders = new Dictionary<int, Order>();
            Cars = new Dictionary<int, Car>();
        }
    }
}