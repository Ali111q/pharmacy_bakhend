
using AutoMapper;
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Entities;
using BackEndStructuer.Repository;
using BackEndStructuer.Services;
using GaragesStructure.DATA;
using GaragesStructure.Repository;

namespace BackEndStructuer.Services;


public interface IDrugPharmacyServices
{
Task<(DrugPharmacyDto? drugpharmacy, string? error)> Create(DrugPharmacyForm drugpharmacyForm );
Task<(List<DrugPharmacyDto> drugpharmacys, int? totalCount, string? error)> GetAll(DrugPharmacyFilter filter);
Task<(DrugPharmacy? drugpharmacy, string? error)> Update(Guid id , DrugPharmacyUpdate drugpharmacyUpdate);
Task<(DrugPharmacy? drugpharmacy, string? error)> Delete(Guid id);

}

public class DrugPharmacyServices : IDrugPharmacyServices
{
private readonly IMapper _mapper;
private readonly IRepositoryWrapper _repositoryWrapper;
private readonly DataContext _context;

public DrugPharmacyServices(IMapper mapper, IRepositoryWrapper repositoryWrapper, DataContext context)
{
    _mapper = mapper;
    _repositoryWrapper = repositoryWrapper;
    _context = context;
}


public async Task<(DrugPharmacyDto? drugpharmacy, string? error)> Create(DrugPharmacyForm drugpharmacyForm )
{
    throw new NotImplementedException() ;
}



public async Task<(List<DrugPharmacyDto> drugpharmacys, int? totalCount, string? error)> GetAll(DrugPharmacyFilter filter)
{
    var (data, currentPage) = await _repositoryWrapper.DrugPharmacy.GetAll<DrugPharmacyDto>(filter.PageNumber, filter.PageSize, filter.Deleted);
    return (data, currentPage, null);
}

public async Task<(DrugPharmacy? drugpharmacy, string? error)> Update(Guid id ,DrugPharmacyUpdate drugpharmacyUpdate)
    {
        throw new NotImplementedException();
      
    }

public async Task<(DrugPharmacy? drugpharmacy, string? error)> Delete(Guid id)
    {
        throw new NotImplementedException();
   
    }

}
