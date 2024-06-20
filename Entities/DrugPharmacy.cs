using GaragesStructure.Entities;

namespace BackEndStructuer.Entities
{
    public class DrugPharmacy : BaseEntity<Guid>
    {
        public int Quantity { get; set; }
        public int CurrentQuantity { get; set; }
        public DateOnly ExpiryDate { get; set; }
        public Guid DrugId { get; set; }
        public Drug Drug { get; set; }
        public decimal UnitPrice { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public List<SellDrug> SellDrugs { get; set; } = default!;
    }
}
