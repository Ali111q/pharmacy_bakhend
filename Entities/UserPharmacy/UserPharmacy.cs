using BackEndStructuer.Entities;

namespace GaragesStructure.Entities.UserPharmacy
{
    public class UserPharmacy : BaseEntity<Guid>
    
    {
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        public Guid PharmacyId { get; set; }
        public Pharmacy Pharmacy { get; set; }
        public PharmacyRole Role { get; set; }
        
    }
}
