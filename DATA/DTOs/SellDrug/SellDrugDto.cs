using BackEndStructuer.Entities;
using GaragesStructure.DATA.DTOs;

namespace BackEndStructuer.DATA.DTOs
{

    public class SellDrugDto : BaseDto<Guid>
    {     
        public Guid DrugPharmacyId{ get; set; }
        public string DrugPharmacyDrugName { get; set; }
        public int DrugPharmacyDrugDose { get; set; }
        public int Quantity { get; set; }
        public decimal DrugPharmacyUnitPrice { get; set; }
    }
}
