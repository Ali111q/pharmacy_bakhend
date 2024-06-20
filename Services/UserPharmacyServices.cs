
using AutoMapper;
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Entities;
using BackEndStructuer.Repository;
using BackEndStructuer.Services;
using GaragesStructure.Entities.UserPharmacy;
using GaragesStructure.Repository;
using Microsoft.AspNetCore.Authorization;

namespace BackEndStructuer.Services;


public interface IUserPharmacyServices
{
Task<(UserPharmacy? userpharmacy, string? error)> Create(UserPharmacyForm userpharmacyForm );
Task<(List<UserPharmacyDto> userpharmacys, int? totalCount, string? error)> GetAll(UserPharmacyFilter filter, Guid userId);
Task<(UserPharmacy? userpharmacy, string? error)> Update(Guid id , UserPharmacyUpdate userpharmacyUpdate);
Task<(UserPharmacy? userpharmacy, string? error)> Delete(Guid id);
}

public class UserPharmacyServices : IUserPharmacyServices
{
private readonly IMapper _mapper;
private readonly IRepositoryWrapper _repositoryWrapper;

public UserPharmacyServices(
    IMapper mapper ,
    IRepositoryWrapper repositoryWrapper
    )
{
    _mapper = mapper;
    _repositoryWrapper = repositoryWrapper;
}
   
   
public async Task<(UserPharmacy? userpharmacy, string? error)> Create(UserPharmacyForm userpharmacyForm )
{
    throw new NotImplementedException();
      
}

public async Task<(List<UserPharmacyDto> userpharmacys, int? totalCount, string? error)> GetAll(UserPharmacyFilter filter, Guid userId)
{
    var (data, totalCount) = await _repositoryWrapper.UserPharmacy.GetAll<UserPharmacyDto>(e => e.UserId == userId );
        return (data, totalCount,null);
    }

public async Task<(UserPharmacy? userpharmacy, string? error)> Update(Guid id ,UserPharmacyUpdate userpharmacyUpdate)
    {
        throw new NotImplementedException();
      
    }

public async Task<(UserPharmacy? userpharmacy, string? error)> Delete(Guid id)
    {
        throw new NotImplementedException();
   
    }

}
