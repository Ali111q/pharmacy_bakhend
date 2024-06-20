
using AutoMapper;
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Entities;
using BackEndStructuer.Repository;
using BackEndStructuer.Services;
using GaragesStructure.Entities.Company;
using GaragesStructure.Repository;

namespace BackEndStructuer.Services;


public interface ICompanyServices
{
Task<(Company? company, string? error)> Create(CompanyForm companyForm );
Task<(List<CompanyDto> companys, int? totalCount, string? error)> GetAll(CompanyFilter filter);
Task<(Company? company, string? error)> Update(Guid id , CompanyUpdate companyUpdate);
Task<(Company? company, string? error)> Delete(Guid id);
}

public class CompanyServices : ICompanyServices
{
private readonly IMapper _mapper;
private readonly IRepositoryWrapper _repositoryWrapper;

public CompanyServices(
    IMapper mapper ,
    IRepositoryWrapper repositoryWrapper
    )
{
    _mapper = mapper;
    _repositoryWrapper = repositoryWrapper;
}
   
   
public async Task<(Company? company, string? error)> Create(CompanyForm companyForm )
{
    Company company= await _repositoryWrapper.Company.Add(_mapper.Map<Company>(companyForm));
    if (company != null)
    {
        return (company, null);
        
    }

    return (null, "Error");

}

public async Task<(List<CompanyDto> companys, int? totalCount, string? error)> GetAll(CompanyFilter filter)
    {
        var (data, totalCount) = await _repositoryWrapper.Company.GetAll<CompanyDto>(filter.PageNumber, filter.PageSize, filter.Deleted);
        return (data, totalCount,null);
    }

public async Task<(Company? company, string? error)> Update(Guid id ,CompanyUpdate companyUpdate)
{
  
        throw new NotImplementedException();
      
    }

public async Task<(Company? company, string? error)> Delete(Guid id)
    {
        throw new NotImplementedException();
   
    }

}
