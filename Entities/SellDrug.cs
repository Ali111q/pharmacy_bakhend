using GaragesStructure.Entities;

namespace BackEndStructuer.Entities
{
    public class SellDrug : BaseEntity<Guid>
    {
        public Guid DrugPharmacyId { get; set; }
        public DrugPharmacy DrugPharmacy { get; set; }
        public Guid SellId { get; set; }
        public Sell Sell { get; set; }
        public int Quantity { get; set; }
    }
}
