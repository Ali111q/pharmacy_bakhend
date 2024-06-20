
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Entities;
using System.Threading.Tasks;
using GaragesStructure.Controllers;
using GaragesStructure.Entities.UserPharmacy;

namespace BackEndStructuer.Controllers
{
    public class UserPharmacysController : BaseController
    {
        private readonly IUserPharmacyServices _userpharmacyServices;

        public UserPharmacysController(IUserPharmacyServices userpharmacyServices)
        {
            _userpharmacyServices = userpharmacyServices;
        }

        
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<UserPharmacyDto>>> GetAll([FromQuery] UserPharmacyFilter filter) => Ok(await _userpharmacyServices.GetAll(filter, Id) , filter.PageNumber , filter.PageSize);

        
        [HttpPost]
        public async Task<ActionResult<UserPharmacy>> Create([FromBody] UserPharmacyForm userpharmacyForm) => Ok(await _userpharmacyServices.Create(userpharmacyForm));

        
        [HttpPut("{id}")]
        public async Task<ActionResult<UserPharmacy>> Update([FromBody] UserPharmacyUpdate userpharmacyUpdate, Guid id) => Ok(await _userpharmacyServices.Update(id , userpharmacyUpdate));

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserPharmacy>> Delete(Guid id) =>  Ok( await _userpharmacyServices.Delete(id));
        
    }
}
