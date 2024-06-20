using GaragesStructure.Entities;

namespace BackEndStructuer.Entities
{
    public class Order : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        public Guid PharmacyId { get; set; }
        public Pharmacy Pharmacy { get; set; }
        public List<DrugPharmacy> DrugPharmacies { get; set; } = default!;

    }
}
