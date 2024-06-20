using GaragesStructure.Entities.Company;

namespace BackEndStructuer.DATA.DTOs
{

    public class DrugForm 
    {
        public string Name { get; set; }
        public Guid CompanyId { get; set; }
        public string Description { get; set; }
        public long Barcode { get; set; }
        public int Dose { get; set; }
    }
}
