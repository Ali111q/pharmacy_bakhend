using AutoMapper;
using BackEndStructuer.DATA;
using BackEndStructuer.Entities;
using BackEndStructuer.Interface;
using GaragesStructure.DATA;
using GaragesStructure.Entities.UserPharmacy;
using GaragesStructure.Repository;

namespace BackEndStructuer.Repository
{

    public class UserPharmacyRepository : GenericRepository<UserPharmacy , Guid> , IUserPharmacyRepository
    {
        public UserPharmacyRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
