
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
    public class PharmacysController : BaseController
    {
        private readonly IPharmacyServices _pharmacyServices;

        public PharmacysController(IPharmacyServices pharmacyServices)
        {
            _pharmacyServices = pharmacyServices;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<PharmacyDto>>> GetAll([FromQuery] PharmacyFilter filter) => Ok(await _pharmacyServices.GetAll(filter) , filter.PageNumber , filter.PageSize);

        
        [HttpPost]
        public async Task<ActionResult<Pharmacy>> Create([FromBody] PharmacyForm pharmacyForm) => Ok(await _pharmacyServices.Create(pharmacyForm));

        [HttpPost("/addUser")]
        public async Task<ActionResult<PharmacyDto>> AddUserToFarmacy([FromBody] AddUserToPharmacyForm pharmacyForm) => Ok(await _pharmacyServices.addUser(pharmacyForm));

        
        [HttpPut("{id}")]
        public async Task<ActionResult<Pharmacy>> Update([FromBody] PharmacyUpdate pharmacyUpdate, Guid id) => Ok(await _pharmacyServices.Update(id , pharmacyUpdate));

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pharmacy>> Delete(Guid id) =>  Ok( await _pharmacyServices.Delete(id));
        
    }
}
