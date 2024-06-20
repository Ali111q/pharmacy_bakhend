using BackEndStructuer.Entities;
using GaragesStructure.Interface;

namespace BackEndStructuer.Interface
{
    public interface IOrderRepository : IGenericRepository<Order , Guid>
    {
         
    }
}
