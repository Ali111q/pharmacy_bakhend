using AutoMapper;
using BackEndStructuer.DATA;
using BackEndStructuer.Entities;
using BackEndStructuer.Interface;
using GaragesStructure.DATA;
using GaragesStructure.Repository;

namespace BackEndStructuer.Repository
{

    public class DeptRepository : GenericRepository<Dept , Guid> , IDeptRepository
    {
        public DeptRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
