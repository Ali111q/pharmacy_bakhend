using AutoMapper;
using BackEndStructuer.DATA;
using BackEndStructuer.Entities;
using BackEndStructuer.Interface;
using GaragesStructure.DATA;
using GaragesStructure.Repository;

namespace BackEndStructuer.Repository
{

    public class PharmacyRepository : GenericRepository<Pharmacy , Guid> , IPharmacyRepository
    {
        public PharmacyRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
