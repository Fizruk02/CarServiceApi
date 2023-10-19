using CarServiceApi.Data;
using CarServiceApi.Models;

namespace CarServiceApi.Services
{
    public class CarService
    {
        private readonly DataProvider _dataProvider;
        public CarService(DataProvider dataProvider) 
        {
            _dataProvider = dataProvider;
        }
        public Dictionary<int, Car> GetAll()
        {
            return _dataProvider.Cars;
        }
        public Car GetById(int id)
        {
            if(!_dataProvider.Cars.ContainsKey(id))
            {
                throw new Exception("Car does not exist!");
            }
            return _dataProvider.Cars[id];
        }
        public Car Create(Car car)
        {
            _dataProvider.Cars.Add(_dataProvider.Cars.Keys.Count, car);
            return car;
        }

        public bool Delete(int id)
        {
            return _dataProvider.Cars.Remove(id);
        }
        public Car Update(int id, Car car)
        {
            _dataProvider.Cars[id] = car;
            return car;
        }
    }
}