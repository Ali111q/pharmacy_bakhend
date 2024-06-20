using System.ComponentModel.DataAnnotations.Schema;
using GaragesStructure.Entities;
using GaragesStructure.Entities.UserPharmacy;

namespace BackEndStructuer.Entities
{
    public class Pharmacy : BaseEntity<Guid>
    {
        public string Name { get; set; }
        [NotMapped]
        public List<AppUser> Users { get; set; } = default!;
        [NotMapped]
        public List<UserPharmacy> UserPharmacies { get; set; } = default!;

        public List<Order> Orders { get; set; } = default!;
        public List<Sell> Sells { get; set; } = default!;
    }
}
