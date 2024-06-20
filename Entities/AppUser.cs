using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BackEndStructuer.Entities;
using Microsoft.EntityFrameworkCore;

namespace GaragesStructure.Entities
{
    public class AppUser : BaseEntity<Guid>
    {
        public string? Email { get; set; }
        
        public string? FullName { get; set; }
        
        public string? Password { get; set; }
        
        public Guid? RoleId { get; set; }
        public Role? Role { get; set; }

        public bool? IsActive { get; set; } = true;
        
        // relations

        [NotMapped]
        public List<Pharmacy> Pharmacies { get; set; } = default!;
        [NotMapped]
        public List<UserPharmacy.UserPharmacy> UserPharmacies { get; set; } = default!;
        [NotMapped] 
        public List<Order> Orders { get; set; }

        public List<Sell> Sells { get; set; }

    }
    
}