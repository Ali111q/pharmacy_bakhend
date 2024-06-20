
using AutoMapper;
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Entities;
using BackEndStructuer.Repository;
using BackEndStructuer.Services;
using GaragesStructure.Repository;

namespace BackEndStructuer.Services;


public interface IDeptServices
{
Task<(Dept? dept, string? error)> Create(DeptForm deptForm );
Task<(List<DeptDto> depts, int? totalCount, string? error)> GetAll(DeptFilter filter);
Task<(Dept? dept, string? error)> Update(Guid id , DeptUpdate deptUpdate);
Task<(Dept? dept, string? error)> Delete(Guid id);
}

public class DeptServices : IDeptServices
{
private readonly IMapper _mapper;
private readonly IRepositoryWrapper _repositoryWrapper;

public DeptServices(
    IMapper mapper ,
    IRepositoryWrapper repositoryWrapper
    )
{
    _mapper = mapper;
    _repositoryWrapper = repositoryWrapper;
}
   
   
public async Task<(Dept? dept, string? error)> Create(DeptForm deptForm )
{
    throw new NotImplementedException();
      
}

public async Task<(List<DeptDto> depts, int? totalCount, string? error)> GetAll(DeptFilter filter)
    {
        throw new NotImplementedException();
    }

public async Task<(Dept? dept, string? error)> Update(Guid id ,DeptUpdate deptUpdate)
    {
        throw new NotImplementedException();
      
    }

public async Task<(Dept? dept, string? error)> Delete(Guid id)
    {
        throw new NotImplementedException();
   
    }

}
