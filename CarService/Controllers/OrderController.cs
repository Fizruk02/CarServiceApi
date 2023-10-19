using CarServiceApi.Models;
using CarServiceApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_orderService.GetAll());
        }
        [HttpGet("{orderId}")]
        public ActionResult Get(int orderId)
        {
            try
            {
                return Ok(_orderService.GetById(orderId));
            }
            catch
            {
                return BadRequest("Order does not exist");
            }
        }
        [HttpPost]
        public ActionResult Post(Order order)
        {
            return Ok(_orderService.Create(order));
        }
        [HttpPut("{orderId}")]
        public ActionResult Update(int orderId, Order order)
        {
            try
            {
                return Ok(_orderService.Update(orderId, order));
            }
            catch
            {
                return BadRequest("Order does not exist");
            }
        }
        [HttpDelete("{orderId}")]
        public ActionResult Delete(int orderId)
        {
            try
            {
                return Ok(_orderService.Delete(orderId));
            }
            catch
            {
                return BadRequest("Order does not exist");
            }
        }
    }
}
