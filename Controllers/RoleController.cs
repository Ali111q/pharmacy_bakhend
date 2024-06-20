using GaragesStructure.DATA.DTOs.roles;
using GaragesStructure.Entities;
using GaragesStructure.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GaragesStructure.Controllers;

public class RoleController :BaseController
{
    public RoleController(IRoleService roleService)
    {
        RoleService = roleService;
    }

    public IRoleService RoleService { get; set; }

    [HttpPost]
    public async Task<ActionResult<RoleDto>> create([FromBody] RoleForm form) => Ok((await RoleService.Add(form)).role);

    [HttpGet]
    public async Task<ActionResult<RoleDto>> getAll() => Ok(await RoleService.GetAll());
}