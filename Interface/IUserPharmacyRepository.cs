using BackEndStructuer.Entities;
using GaragesStructure.Entities.UserPharmacy;
using GaragesStructure.Interface;

namespace BackEndStructuer.Interface
{
    public interface IUserPharmacyRepository : IGenericRepository<UserPharmacy , Guid>
    {
         
    }
}
