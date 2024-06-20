using GaragesStructure.Entities;
using GaragesStructure.Entities.Company;

namespace BackEndStructuer.Entities
{
    public class Drug : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long Barcode { get; set; }
        public int Dose { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public List<DrugPharmacy> DrugPharmacies { get; set; } = default!;

    }
}
