using AutoMapper;
using BackEndStructuer.DATA;
using BackEndStructuer.Entities;
using BackEndStructuer.Interface;
using GaragesStructure.DATA;
using GaragesStructure.Entities.Company;
using GaragesStructure.Repository;

namespace BackEndStructuer.Repository
{

    public class CompanyRepository : GenericRepository<Company , Guid> , ICompanyRepository
    {
        public CompanyRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
