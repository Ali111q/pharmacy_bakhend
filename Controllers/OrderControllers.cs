
using BackEndStructuer.DATA.DTOs;

using BackEndStructuer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Entities;
using System.Threading.Tasks;
using GaragesStructure.Controllers;

namespace BackEndStructuer.Controllers
{
    public class OrdersController : BaseController
    {
        private readonly IOrderServices _orderServices;

        public OrdersController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> GetAll([FromQuery] OrderFilter filter) => Ok(await _orderServices.GetAll(filter) , filter.PageNumber , filter.PageSize);

        
        [HttpPost]
        public async Task<ActionResult<OrderDto>> Create([FromBody] OrderForm orderForm) => Ok(await _orderServices.Create(orderForm));

        
        [HttpPut("{id}")]
        public async Task<ActionResult<Order>> Update([FromBody] OrderUpdate orderUpdate, Guid id) => Ok(await _orderServices.Update(id , orderUpdate));

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> Delete(Guid id) =>  Ok( await _orderServices.Delete(id));
        
    }
}
