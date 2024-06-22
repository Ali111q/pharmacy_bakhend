using GaragesStructure.DATA.DTOs;

namespace BackEndStructuer.DATA.DTOs
{

    public class OrderFilter : BaseFilter 
    {
        public Guid PharmacyId { get; set; }
    }
}
