using GaragesStructure.DATA.DTOs;

namespace BackEndStructuer.DATA.DTOs
{

    public class SellFilter : BaseFilter 
    {
        public Guid? UserId { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
        public int? Day { get; set; }
        public bool? IsDept { get; set; }
    }
}
