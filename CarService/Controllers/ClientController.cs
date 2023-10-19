using CarServiceApi.Models;
using CarServiceApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : Controller
    {
        private readonly ClientService _clientService;

        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_clientService.GetAll());
        }
        [HttpGet("{clientId}")]
        public ActionResult Get(int clientId)
        {
            try
            {
                return Ok(_clientService.GetById(clientId));
            }
            catch
            {
                return BadRequest("Client does not exist");
            }
        }
        [HttpPost]
        public ActionResult Post(Client client)
        {
            return Ok(_clientService.Create(client));
        }
        [HttpPut("{clientId}")]
        public ActionResult Update(int clientId, Client client)
        {
            try
            {
                return Ok(_clientService.Update(clientId, client));
            }
            catch
            {
                return BadRequest("Client does not exist");
            }
        }
        [HttpDelete("{clientId}")]
        public ActionResult Delete(int clientId)
        {
            try
            {
                return Ok(_clientService.Delete(clientId));
            }
            catch
            {
                return BadRequest("Client does not exist");
            }
        }
        [HttpGet("{clientId}/orders")]
        public ActionResult GetOrders(int clientId)
        {
            try
            {
                return Ok(_clientService.GetOrdersByClient(clientId));
            }
            catch
            {
                return BadRequest("Client does not exist");
            }
        }
        [HttpGet("{clientId}/cars")]
        public ActionResult GetCarsByClient(int clientId)
        {
            try
            {
                return Ok(_clientService.GetCarsByClient(clientId));
            }
            catch
            {
                return BadRequest("Order does not exist");
            }
        }
    }
}
