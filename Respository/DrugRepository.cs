using AutoMapper;
using BackEndStructuer.DATA;
using BackEndStructuer.Entities;
using BackEndStructuer.Interface;
using GaragesStructure.DATA;
using GaragesStructure.Repository;

namespace BackEndStructuer.Repository
{

    public class DrugRepository : GenericRepository<Drug , Guid> , IDrugRepository
    {
        public DrugRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
