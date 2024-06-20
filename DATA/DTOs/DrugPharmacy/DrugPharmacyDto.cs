using GaragesStructure.DATA.DTOs;
using GaragesStructure.Entities.Company;

namespace BackEndStructuer.DATA.DTOs
{

    public class DrugPharmacyDto : BaseDto<Guid>
    {
        public string DrugName { get; set; }
        public int Quantity { get; set; }
        public int CurrentQuantity { get; set; }
        public DateOnly ExpiryDate { get; set; }
        public long DrugBarcode { get; set; }
        public int Dose { get; set; }
        public decimal UnitPrice { get; set; }
        public string DrugCompanyName { get; set; }
    }
}
