
using AutoMapper;
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Entities;
using BackEndStructuer.Repository;
using BackEndStructuer.Services;
using GaragesStructure.Repository;

namespace BackEndStructuer.Services;


public interface IOrderServices
{
Task<(OrderDto? order, string? error)> Create(OrderForm orderForm );
Task<(List<OrderDto> orders, int? totalCount, string? error)> GetAll(OrderFilter filter);
Task<(Order? order, string? error)> Update(Guid id , OrderUpdate orderUpdate);
Task<(Order? order, string? error)> Delete(Guid id);
}

public class OrderServices : IOrderServices
{
private readonly IMapper _mapper;
private readonly IRepositoryWrapper _repositoryWrapper;

public OrderServices(
    IMapper mapper ,
    IRepositoryWrapper repositoryWrapper
    )
{
    _mapper = mapper;
    _repositoryWrapper = repositoryWrapper;
}
   
   
public async Task<(OrderDto? order, string? error)> Create(OrderForm orderForm )
{
   
    List<DrugPharmacy> drugPharmacies = [];
    foreach (var item in orderForm.DrugPharmacy)
    {
        DrugPharmacy drugPharmacy = new DrugPharmacy
        {
            Id = Guid.NewGuid(),
            DrugId = item.DrugId,
            Quantity = item.Quantity,
            CurrentQuantity = item.Quantity,
            UnitPrice = item.UnitPrice,
            ExpiryDate = DateOnly.FromDateTime(item.ExpiryDate),
        };
        drugPharmacies.Add(drugPharmacy);
    }
    Order order = new Order
    {
        Id = Guid.NewGuid(),
        UserId = orderForm.UserId,
        DrugPharmacies = drugPharmacies,
        PharmacyId = orderForm.PharmacyId,
    };
    Order o = await _repositoryWrapper.Order.Add(order);
        
    return (_mapper.Map<OrderDto>(o), null);

      
}

public async Task<(List<OrderDto> orders, int? totalCount, string? error)> GetAll(OrderFilter filter)
    {
        var (data, totalCount) = await _repositoryWrapper.Order.GetAll<OrderDto>(e=>filter.PharmacyId == e.PharmacyId , filter.PageNumber, filter.PageSize,filter.Deleted);
      
        foreach (var orderDto in data)
        {
          orderDto.TotalPrice = orderDto.DrugPharmacies.Sum(e=>e.UnitPrice * e.Quantity);  
          
        }
        return (data, totalCount, null);
    }

public async Task<(Order? order, string? error)> Update(Guid id ,OrderUpdate orderUpdate)
    {
        throw new NotImplementedException();
      
    }

public async Task<(Order? order, string? error)> Delete(Guid id)
    {
        throw new NotImplementedException();
   
    }

}
