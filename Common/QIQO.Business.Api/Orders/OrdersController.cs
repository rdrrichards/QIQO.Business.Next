using Microsoft.AspNetCore.Mvc;
using QIQO.Orders.Domain;
using QIQO.Orders.Manager;
using System.Threading.Tasks;

namespace QIQO.Business.Api.Orders
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IOrdersManager _ordersManager;

        public OrdersController(IOrdersManager ordersManager)
        {
            _ordersManager = ordersManager;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // return Ok(new string[] { "Order1", "Order2" });
            return Ok(await _ordersManager.GetOrdersAsync());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _ordersManager.GetOrderAsync(id));
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]OrderAddViewModel orderAddViewModel)
        {
            if (ModelState.IsValid)
            {
                await _ordersManager.SaveOrderAsync(new Order(orderAddViewModel.OrderNumber, orderAddViewModel.OrderEntryDate));
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]OrderUpdateViewModel orderUpdateViewModel)
        {
            await _ordersManager.SaveOrderAsync(new Order(orderUpdateViewModel.OrderKey, orderUpdateViewModel.OrderEntryDate));
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _ordersManager.DeleteOrderAsync(id);
            return Ok();
        }
    }
}
