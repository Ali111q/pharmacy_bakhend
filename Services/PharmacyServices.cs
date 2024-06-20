
using AutoMapper;
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Entities;
using BackEndStructuer.Repository;
using BackEndStructuer.Services;
using GaragesStructure.DATA;
using GaragesStructure.Entities;
using GaragesStructure.Entities.UserPharmacy;
using GaragesStructure.Repository;
using Microsoft.EntityFrameworkCore;
using OneSignalApi.Model;
using Polly;

namespace BackEndStructuer.Services;


public interface IPharmacyServices
{
Task<(Pharmacy? pharmacy, string? error)> Create(PharmacyForm pharmacyForm );
Task<(List<PharmacyDto> pharmacys, int? totalCount, string? error)> GetAll(PharmacyFilter filter);
Task<(Pharmacy? pharmacy, string? error)> Update(Guid id , PharmacyUpdate pharmacyUpdate);
Task<(Pharmacy? pharmacy, string? error)> Delete(Guid id);
Task<(PharmacyDto? pharmcy, string? error)> addUser(AddUserToPharmacyForm form);
}

public class PharmacyServices : IPharmacyServices
{
private readonly IMapper _mapper;
private readonly IRepositoryWrapper _repositoryWrapper;
private readonly DataContext _context;

public PharmacyServices(IMapper mapper, IRepositoryWrapper repositoryWrapper, DataContext context)
{
    _mapper = mapper;
    _repositoryWrapper = repositoryWrapper;
    _context = context;
}


public async Task<(Pharmacy? pharmacy, string? error)> Create(PharmacyForm pharmacyForm )
{
    
    Pharmacy pharmacy = await _repositoryWrapper.Pharmacy.Add(_mapper.Map<Pharmacy>(pharmacyForm
    ));
    
    return (pharmacy, null);
      
}

public async Task<(PharmacyDto? pharmcy, string? error)> addUser(AddUserToPharmacyForm form)
{
    try
    {
       
        
        UserPharmacy userPharmacy = new UserPharmacy 
            { UserId = form.UserId, PharmacyId = form.PharmacyId ,Role = form.PharmacyRole, Id = Guid.NewGuid()};
       await _repositoryWrapper.UserPharmacy.Add(userPharmacy);
       

        return (_mapper.Map<PharmacyDto>(await _repositoryWrapper.Pharmacy.GetById(form.PharmacyId)), null);
    }
    catch (Exception e)
    {
        return (null, e.Message);

    }
}
public async Task<(List<PharmacyDto> pharmacys, int? totalCount, string? error)> GetAll(PharmacyFilter filter)
{
    var (data, currentPage) = await _repositoryWrapper.Pharmacy.GetAll<PharmacyDto>(filter.PageNumber,filter.PageSize,filter.Deleted);
    return (data, currentPage, null);
}

public async Task<(Pharmacy? pharmacy, string? error)> Update(Guid id ,PharmacyUpdate pharmacyUpdate)
    {
        throw new NotImplementedException();
      
    }

public async Task<(Pharmacy? pharmacy, string? error)> Delete(Guid id)
    {
        throw new NotImplementedException();
   
    }

}
