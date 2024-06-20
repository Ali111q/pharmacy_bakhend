using AutoMapper;
using BackEndStructuer.DATA;
using BackEndStructuer.Entities;
using BackEndStructuer.Interface;
using GaragesStructure.DATA;
using GaragesStructure.Repository;

namespace BackEndStructuer.Repository
{

    public class OrderRepository : GenericRepository<Order , Guid> , IOrderRepository
    {
        public OrderRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
