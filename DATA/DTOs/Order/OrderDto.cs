using GaragesStructure.DATA.DTOs;

namespace BackEndStructuer.DATA.DTOs
{

    public class OrderDto: BaseDto<Guid>
    {
        public string UserFullName { get; set; }
        public Guid PharmacyId { get; set; }
        public List<DrugPharmacyDto> DrugPharmacies { get; set; }
        public  decimal TotalPrice { get; set; }
    }
}
