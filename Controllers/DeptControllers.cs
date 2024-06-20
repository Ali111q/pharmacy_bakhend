
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
    public class DeptsController : BaseController
    {
        private readonly IDeptServices _deptServices;

        public DeptsController(IDeptServices deptServices)
        {
            _deptServices = deptServices;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<DeptDto>>> GetAll([FromQuery] DeptFilter filter) => Ok(await _deptServices.GetAll(filter) , filter.PageNumber , filter.PageSize);

        
        [HttpPost]
        public async Task<ActionResult<Dept>> Create([FromBody] DeptForm deptForm) => Ok(await _deptServices.Create(deptForm));

        
        [HttpPut("{id}")]
        public async Task<ActionResult<Dept>> Update([FromBody] DeptUpdate deptUpdate, Guid id) => Ok(await _deptServices.Update(id , deptUpdate));

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dept>> Delete(Guid id) =>  Ok( await _deptServices.Delete(id));
        
    }
}
