
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
    public class SellDrugsController : BaseController
    {
        private readonly ISellDrugServices _selldrugServices;

        public SellDrugsController(ISellDrugServices selldrugServices)
        {
            _selldrugServices = selldrugServices;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<SellDrugDto>>> GetAll([FromQuery] SellDrugFilter filter) => Ok(await _selldrugServices.GetAll(filter) , filter.PageNumber , filter.PageSize);

        
        [HttpPost]
        public async Task<ActionResult<SellDrug>> Create([FromBody] SellDrugForm selldrugForm) => Ok(await _selldrugServices.Create(selldrugForm));

        
        [HttpPut("{id}")]
        public async Task<ActionResult<SellDrug>> Update([FromBody] SellDrugUpdate selldrugUpdate, Guid id) => Ok(await _selldrugServices.Update(id , selldrugUpdate));

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<SellDrug>> Delete(Guid id) =>  Ok( await _selldrugServices.Delete(id));
        
    }
}
