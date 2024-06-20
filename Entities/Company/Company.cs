using System.ComponentModel.DataAnnotations.Schema;
using BackEndStructuer.Entities;

namespace GaragesStructure.Entities.Company
{
    public class Company : BaseEntity<Guid>
    {
        public string Name { get; set; }
        [NotMapped]
        public List<Drug> Drugs { get; set; }
        public Country Country { get; set; }
    }
}
