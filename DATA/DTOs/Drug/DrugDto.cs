using GaragesStructure.DATA.DTOs;

namespace BackEndStructuer.DATA.DTOs
{

    public class DrugDto : BaseDto<Guid>
    {
        public string Name { get; set; }
        public long Barcode { get; set; }
        public string CompanyName { get; set; }
    }
}
