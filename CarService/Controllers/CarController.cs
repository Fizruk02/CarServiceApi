using CarServiceApi.Models;
using CarServiceApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : Controller
    {
        private readonly CarService _carService;

        public CarController(CarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_carService.GetAll());
        }
        [HttpGet("{carId}")]
        public ActionResult Get(int carId)
        {
            try
            {
                return Ok(_carService.GetById(carId));
            }
            catch
            {
                return BadRequest("Car does not exist");
            }
        }
        [HttpPost]
        public ActionResult Post(Car car)
        {
            return Ok(_carService.Create(car));
        }
        [HttpPut("{carId}")]
        public ActionResult Update(int carId, Car car)
        {
            try
            {
                return Ok(_carService.Update(carId, car));
            }
            catch
            {
                return BadRequest("Car does not exist");
            }
        }
        [HttpDelete("{carId}")]
        public ActionResult Delete(int carId)
        {
            try
            {
                return Ok(_carService.Delete(carId));
            }
            catch
            {
                return BadRequest("Car does not exist");
            }
        }
    }
}
