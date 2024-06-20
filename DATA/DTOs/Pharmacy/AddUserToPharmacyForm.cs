using GaragesStructure.Entities.UserPharmacy;

namespace BackEndStructuer.DATA.DTOs;

public class AddUserToPharmacyForm
{
    public Guid UserId { get; set; }
    public Guid PharmacyId { get; set; }
    public PharmacyRole PharmacyRole {
        get;
        set;
    }
}