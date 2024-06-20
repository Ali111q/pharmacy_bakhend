
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
    public class SellsController : BaseController
    {
        private readonly ISellServices _sellServices;

        public SellsController(ISellServices sellServices)
        {
            _sellServices = sellServices;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<SellDto>>> GetAll([FromQuery] SellFilter filter) => Ok(await _sellServices.GetAll(filter) , filter.PageNumber , filter.PageSize);

        
        [HttpPost]
        public async Task<ActionResult<SellDto>> Create([FromBody] SellForm sellForm) => Ok(await _sellServices.Create(sellForm));

        
        [HttpPut("{id}")]
        public async Task<ActionResult<Sell>> Update([FromBody] SellUpdate sellUpdate, Guid id) => Ok(await _sellServices.Update(id , sellUpdate));

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sell>> Delete(Guid id) =>  Ok( await _sellServices.Delete(id));
        
    }
}
