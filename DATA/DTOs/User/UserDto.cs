using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Entities;
using GaragesStructure.DATA.DTOs.roles;
using GaragesStructure.Entities.UserPharmacy;

namespace GaragesStructure.DATA.DTOs.User
{
    public class UserDto : BaseDto<Guid>
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        
        public string Email { get; set; }
        public RoleDto? Role { get; set; }
        public string Token { get; set; }
        
        public bool? IsActive { get; set; }
        public List<UserPharmacyDto> UserPharmacies { get; set; }
    }
}