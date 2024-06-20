using GaragesStructure.DATA.DTOs.Home;
using GaragesStructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace GaragesStructure.Controllers;

public class HomeController: BaseController
{
    private readonly IHomeService HomeService;

    public HomeController(IHomeService homeService)
    {
        HomeService = homeService;
    }

    [HttpGet]
    public async Task<ActionResult<HomeDto>>  GetHome([FromQuery] HomeFilter filter) => Ok(await HomeService.GetHome(filter));
}