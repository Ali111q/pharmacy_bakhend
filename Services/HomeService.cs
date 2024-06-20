using AutoMapper;
using BackEndStructuer.DATA.DTOs;
using GaragesStructure.DATA.DTOs.Home;
using GaragesStructure.DATA.DTOs.Home.Orders;
using GaragesStructure.DATA.DTOs.Home.Sales;
using GaragesStructure.Repository;

namespace GaragesStructure.Services;

public interface IHomeService
{
    Task<(HomeDto? homeDto, string? error)> GetHome(HomeFilter homeFilter);
}

public class HomeService : IHomeService
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public HomeService(IMapper mapper, IRepositoryWrapper repositoryWrapper)
    {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
    }

    public async  Task<(HomeDto? homeDto, string? error)> GetHome(HomeFilter homeFilter)
    {
        HomeDto homeDto = new HomeDto();
        var (sales, totalCount) = await _repositoryWrapper.Sell.GetAll<SellDto>(
            // make filter to get all sales today 
            e=> 
                e.CreationDate.Value.Day == DateTime.Now.Day
                &&
                e.PharmacyId == homeFilter.PharmacyId,pageNumber:1,pageSize:5,deleted:false
            );
   var (orders, totalCount2) = await _repositoryWrapper.Order.GetAll<OrderDto>(
            // make filter to get all orders today 
            e=> 
                e.PharmacyId == homeFilter.PharmacyId,pageNumber:1,pageSize:5,deleted:false
            );
        // change sales to list of HomeSalesDto
        List<HomeSalesDto> _salesDtos = [];
        List<HomeOrdersDto> _ordersDtos = [];
        // if (sales != null && sales.Count != 0 && totalCount != 0) 
        // {


            foreach (var sale in sales)
            {
                HomeSalesDto salesDto = new HomeSalesDto();
                salesDto.Discount = sale.Discount;
                salesDto.CreationDate = sale.CreationDate;
                salesDto.Id = sale.Id;
                salesDto.TotalPrice = sale.SellDrugs.Sum(x => (x.Quantity * x.DrugPharmacyUnitPrice));

                salesDto.Quantity = sale.SellDrugs.Sum(e => e.Quantity);

            // }
            _salesDtos.Add(salesDto);
        }
            
            foreach (var orderDto in orders)
            {
                HomeOrdersDto homeOrdersDto = new HomeOrdersDto
                {
                    UserFullName = orderDto.UserFullName,
                    TotalPrice = orderDto.DrugPharmacies.Sum(e => e.Quantity * e.UnitPrice)
                };
                
                _ordersDtos.Add(homeOrdersDto);
            }

            homeDto.Orders = _ordersDtos;
        homeDto.Sales = _salesDtos;
        return (homeDto,  null);
    }
}