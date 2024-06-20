using GaragesStructure.DATA.DTOs;

namespace BackEndStructuer.DATA.DTOs
{

    public class SellDto : BaseDto<Guid>
    {
        public string UserFullName { get; set; }
        public List<SellDrugDto> SellDrugs { get; set; }
        public string PharmacyName { get; set; }
        public decimal Discount { get; set; }
        public decimal TotlaPrice { get; set; }
    }
}
