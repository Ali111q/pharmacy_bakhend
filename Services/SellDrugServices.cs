
using AutoMapper;
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Entities;
using BackEndStructuer.Repository;
using BackEndStructuer.Services;
using GaragesStructure.Repository;

namespace BackEndStructuer.Services;


public interface ISellDrugServices
{
Task<(SellDrug? selldrug, string? error)> Create(SellDrugForm selldrugForm );
Task<(List<SellDrugDto> selldrugs, int? totalCount, string? error)> GetAll(SellDrugFilter filter);
Task<(SellDrug? selldrug, string? error)> Update(Guid id , SellDrugUpdate selldrugUpdate);
Task<(SellDrug? selldrug, string? error)> Delete(Guid id);
}

public class SellDrugServices : ISellDrugServices
{
private readonly IMapper _mapper;
private readonly IRepositoryWrapper _repositoryWrapper;

public SellDrugServices(
    IMapper mapper ,
    IRepositoryWrapper repositoryWrapper
    )
{
    _mapper = mapper;
    _repositoryWrapper = repositoryWrapper;
}
   
   
public async Task<(SellDrug? selldrug, string? error)> Create(SellDrugForm selldrugForm )
{
    throw new NotImplementedException();
      
}

public async Task<(List<SellDrugDto> selldrugs, int? totalCount, string? error)> GetAll(SellDrugFilter filter)
    {
        throw new NotImplementedException();
    }

public async Task<(SellDrug? selldrug, string? error)> Update(Guid id ,SellDrugUpdate selldrugUpdate)
    {
        throw new NotImplementedException();
      
    }

public async Task<(SellDrug? selldrug, string? error)> Delete(Guid id)
    {
        throw new NotImplementedException();
   
    }

}
