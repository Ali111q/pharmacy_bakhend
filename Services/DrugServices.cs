
using AutoMapper;
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Entities;
using BackEndStructuer.Repository;
using BackEndStructuer.Services;
using GaragesStructure.Entities.Company;
using GaragesStructure.Repository;

namespace BackEndStructuer.Services;


public interface IDrugServices
{
Task<(DrugDto? drug, string? error)> Create(DrugForm drugForm );
Task<(List<DrugDto> drugs, int? totalCount, string? error)> GetAll(DrugFilter filter);
Task<(Drug? drug, string? error)> Update(Guid id , DrugUpdate drugUpdate);
Task<(Drug? drug, string? error)> Delete(Guid id);
}

public class DrugServices : IDrugServices
{
private readonly IMapper _mapper;
private readonly IRepositoryWrapper _repositoryWrapper;

public DrugServices(
    IMapper mapper ,
    IRepositoryWrapper repositoryWrapper
    )
{
    _mapper = mapper;
    _repositoryWrapper = repositoryWrapper;
}
   
   
public async Task<(DrugDto? drug, string? error)> Create(DrugForm drugForm )
{
    Company company =  await _repositoryWrapper.Company.GetById(drugForm.CompanyId);
    Drug drug = _mapper.Map<Drug>(drugForm);
    drug.Company = company;
    Drug databaseDrug = await _repositoryWrapper.Drug.Add(drug);
    if (databaseDrug != null)
    {
        return (_mapper.Map<DrugDto>(databaseDrug), null);
    }

    return (null, "Error");
}

public async Task<(List<DrugDto> drugs, int? totalCount, string? error)> GetAll(DrugFilter filter)
{
   var (data, totalCount) = await _repositoryWrapper.Drug.GetAll<DrugDto>(filter.PageNumber, filter.PageSize, filter.Deleted);
   return (data, totalCount, null);
}

public async Task<(Drug? drug, string? error)> Update(Guid id ,DrugUpdate drugUpdate)
    {
        throw new NotImplementedException();
      
    }

public async Task<(Drug? drug, string? error)> Delete(Guid id)
    {
        throw new NotImplementedException();
   
    }

}
