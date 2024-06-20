using AutoMapper;
using BackEndStructuer.DATA;
using BackEndStructuer.Entities;
using BackEndStructuer.Interface;
using GaragesStructure.DATA;
using GaragesStructure.Repository;

namespace BackEndStructuer.Repository
{

    public class SellDrugRepository : GenericRepository<SellDrug , Guid> , ISellDrugRepository
    {
        public SellDrugRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
