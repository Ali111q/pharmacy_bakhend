using BackEndStructuer.Entities;
using GaragesStructure.DATA.DTOs;
using GaragesStructure.Entities.UserPharmacy;

namespace BackEndStructuer.DATA.DTOs
{

    public class UserPharmacyDto : BaseDto<Guid>
    {
        public Guid PharmacyId { get; set; }
        public string PharmacyName { get; set; }
        public Guid UserId { get; set; }
        public PharmacyRole Role { get; set; }
    }
}
