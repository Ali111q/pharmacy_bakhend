
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Entities;
using System.Threading.Tasks;
using GaragesStructure.Controllers;
using GaragesStructure.Entities.Company;

namespace BackEndStructuer.Controllers
{
    public class CompanysController : BaseController
    {
        private readonly ICompanyServices _companyServices;

        public CompanysController(ICompanyServices companyServices)
        {
            _companyServices = companyServices;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<CompanyDto>>> GetAll([FromQuery] CompanyFilter filter) => Ok(await _companyServices.GetAll(filter) , filter.PageNumber , filter.PageSize);

        
        [HttpPost]
        public async Task<ActionResult<Company>> Create([FromBody] CompanyForm companyForm) => Ok(await _companyServices.Create(companyForm));

        
        [HttpPut("{id}")]
        public async Task<ActionResult<Company>> Update([FromBody] CompanyUpdate companyUpdate, Guid id) => Ok(await _companyServices.Update(id , companyUpdate));

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Company>> Delete(Guid id) =>  Ok( await _companyServices.Delete(id));
        
    }
}
