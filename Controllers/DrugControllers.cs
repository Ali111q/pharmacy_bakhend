
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
    public class DrugsController : BaseController
    {
        private readonly IDrugServices _drugServices;

        public DrugsController(IDrugServices drugServices)
        {
            _drugServices = drugServices;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<DrugDto>>> GetAll([FromQuery] DrugFilter filter) => Ok(await _drugServices.GetAll(filter) , filter.PageNumber , filter.PageSize);

        
        [HttpPost]
        public async Task<ActionResult<DrugDto>> Create([FromBody] DrugForm drugForm) => Ok(await _drugServices.Create(drugForm));

        
        [HttpPut("{id}")]
        public async Task<ActionResult<Drug>> Update([FromBody] DrugUpdate drugUpdate, Guid id) => Ok(await _drugServices.Update(id , drugUpdate));

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Drug>> Delete(Guid id) =>  Ok( await _drugServices.Delete(id));
        
    }
}
