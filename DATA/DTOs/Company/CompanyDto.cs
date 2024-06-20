using BackEndStructuer.Entities;
using GaragesStructure.DATA.DTOs;
using GaragesStructure.Entities.Company;

namespace BackEndStructuer.DATA.DTOs
{

    public class CompanyDto:BaseDto<Guid>
    {
        public string Name { get; set; }
        public Country Country { get; set; }
        public List<Drug> Drugs { get; set; }
    }
}
