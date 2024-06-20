
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
    public class DrugPharmacysController : BaseController
    {
        private readonly IDrugPharmacyServices _drugpharmacyServices;

        public DrugPharmacysController(IDrugPharmacyServices drugpharmacyServices)
        {
            _drugpharmacyServices = drugpharmacyServices;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<DrugPharmacyDto>>> GetAll([FromQuery] DrugPharmacyFilter filter) => Ok(await _drugpharmacyServices.GetAll(filter) , filter.PageNumber , filter.PageSize);

        
        [HttpPost]
        public async Task<ActionResult<DrugPharmacyDto>> Create([FromBody] DrugPharmacyForm drugpharmacyForm) => Ok(await _drugpharmacyServices.Create(drugpharmacyForm));
        
   
        [HttpPut("{id}")]
        public async Task<ActionResult<DrugPharmacy>> Update([FromBody] DrugPharmacyUpdate drugpharmacyUpdate, Guid id) => Ok(await _drugpharmacyServices.Update(id , drugpharmacyUpdate));

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<DrugPharmacy>> Delete(Guid id) =>  Ok( await _drugpharmacyServices.Delete(id));
        
    }
}
