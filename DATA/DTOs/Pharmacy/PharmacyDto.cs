using GaragesStructure.DATA.DTOs;
using GaragesStructure.Entities;
using GaragesStructure.Entities.UserPharmacy;

namespace BackEndStructuer.DATA.DTOs
{

    public class PharmacyDto : BaseDto<Guid>
    {
        public string Name { get; set; }
        
    }
}
