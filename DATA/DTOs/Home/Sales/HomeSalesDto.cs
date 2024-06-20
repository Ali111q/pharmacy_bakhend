namespace GaragesStructure.DATA.DTOs.Home.Sales;

public class HomeSalesDto:BaseDto<Guid>
{
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal Discount { get; set; }
}