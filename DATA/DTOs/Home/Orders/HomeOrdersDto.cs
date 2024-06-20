namespace GaragesStructure.DATA.DTOs.Home.Orders;

public class HomeOrdersDto: BaseDto<Guid>
{
    public string UserFullName { get; set; }
    public decimal TotalPrice { get; set; }
}