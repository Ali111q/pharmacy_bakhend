using BackEndStructuer.Entities;
using GaragesStructure.Entities.Company;
using GaragesStructure.Interface;

namespace BackEndStructuer.Interface
{
    public interface ICompanyRepository : IGenericRepository<Company , Guid>
    {
         
    }
}
