using AutoMapper;
using BackEndStructuer.DATA;
using BackEndStructuer.Entities;
using BackEndStructuer.Interface;
using GaragesStructure.DATA;
using GaragesStructure.Repository;

namespace BackEndStructuer.Repository
{

    public class SellRepository : GenericRepository<Sell , Guid> , ISellRepository
    {
        public SellRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
