using GaragesStructure.DATA.DTOs.Home.Orders;
using GaragesStructure.DATA.DTOs.Home.Sales;

namespace GaragesStructure.DATA.DTOs.Home;

public class HomeDto
{
    public List<HomeSalesDto> Sales { get; set; }
    public List<HomeOrdersDto> Orders { get; set; }
}