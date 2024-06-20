using GaragesStructure.Entities;

namespace BackEndStructuer.Entities
{
    public class Sell : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        public Guid PharmacyId { get; set; }
        public Pharmacy Pharmacy { get; set; }
        public List<SellDrug> SellDrugs { get; set; } = default!;
        public decimal Discount { get; set; }
        public Guid? DeptId { get; set; }
        public Dept? Dept { get; set; }
    }
}
