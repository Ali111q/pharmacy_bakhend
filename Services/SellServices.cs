
using AutoMapper;
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Entities;
using BackEndStructuer.Repository;
using BackEndStructuer.Services;
using GaragesStructure.Repository;

namespace BackEndStructuer.Services;


public interface ISellServices
{
Task<(SellDto? sell, string? error)> Create(SellForm sellForm );
Task<(List<SellDto> sells, int? totalCount, string? error)> GetAll(SellFilter filter);
Task<(Sell? sell, string? error)> Update(Guid id , SellUpdate sellUpdate);
Task<(Sell? sell, string? error)> Delete(Guid id);
}

public class SellServices : ISellServices
{
private readonly IMapper _mapper;
private readonly IRepositoryWrapper _repositoryWrapper;

public SellServices(
    IMapper mapper ,
    IRepositoryWrapper repositoryWrapper
    )
{
    _mapper = mapper;
    _repositoryWrapper = repositoryWrapper;
}
   
   
public async Task<(SellDto? sell, string? error)> Create(SellForm sellForm )
{
    var sell = _mapper.Map<Sell>(sellForm);
    var createdSell = await _repositoryWrapper.Sell.Add(sell);

    var selles = _mapper.Map<SellDto>(createdSell);
    
    // get selles as Dto from databse
    var sellDto = await _repositoryWrapper.Sell.Get<SellDto>(e=>e.Id == sell.Id);
    
    // reduce current quantity from drugpharmacy based on selled quantity
    foreach (var sellDrug in sellDto.SellDrugs)
    {
        var drugPharmacy = await _repositoryWrapper.DrugPharmacy.Get(e=>e.Id == sellDrug.DrugPharmacyId);
        drugPharmacy.CurrentQuantity -= sellDrug.Quantity;
        await _repositoryWrapper.DrugPharmacy.Update(drugPharmacy);
    }
    
    // calculate total price for the sell
    sellDto.TotlaPrice = sellDto.SellDrugs.Sum(x => (x.Quantity * x.DrugPharmacyUnitPrice))-sellDto.Discount;
    return ( sellDto, null);
}

public async Task<(List<SellDto> sells, int? totalCount, string? error)> GetAll(SellFilter filter)
    {
        var (data, totalCount) = await _repositoryWrapper.Sell.GetAll<SellDto>(e=>

            (filter.Day == null || filter.Day == e.CreationDate.Value.Day)&&
            (filter.Month == null || filter.Month == e.CreationDate.Value.Month)&&
            (filter.Year == null || filter.Year == e.CreationDate.Value.Year)&&
            (filter.UserId == null || filter.UserId == e.UserId)
            &&
            (filter.IsDept == null || filter.IsDept.Equals(e.DeptId  != null)),
            filter.PageNumber, filter.PageSize, filter.Deleted);
      
            // edit the data to add total price for it 
            foreach (var sellDto in data)
            {
                sellDto.TotlaPrice = sellDto.SellDrugs.Sum(x => (x.Quantity * x.DrugPharmacyUnitPrice))-sellDto.Discount;
            }
         
        return (data, totalCount, null);
    }

public async Task<(Sell? sell, string? error)> Update(Guid id ,SellUpdate sellUpdate)
    {
        
        throw new NotImplementedException();
      
    }

public async Task<(Sell? sell, string? error)> Delete(Guid id)
    {
        throw new NotImplementedException();
   
    }

}
