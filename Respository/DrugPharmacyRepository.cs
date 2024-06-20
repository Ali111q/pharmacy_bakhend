using AutoMapper;
using BackEndStructuer.DATA;
using BackEndStructuer.Entities;
using BackEndStructuer.Interface;
using GaragesStructure.DATA;
using GaragesStructure.Repository;

namespace BackEndStructuer.Repository
{

    public class DrugPharmacyRepository : GenericRepository<DrugPharmacy , Guid> , IDrugPharmacyRepository
    {
        public DrugPharmacyRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
