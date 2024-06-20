using GaragesStructure.DATA.DTOs;
using GaragesStructure.Entities.Company;

namespace BackEndStructuer.DATA.DTOs
{

    public class CompanyFilter : BaseFilter 
    {
        public Country Country { get; set; }
    }
}
