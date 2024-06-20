using BackEndStructuer.Interface;
using GaragesStructure.Interface;

namespace GaragesStructure.Repository
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IPermissionRepository Permission { get; }

        IRoleRepository Role { get; }

        // here to add
IDeptRepository Dept{get;}
ISellRepository Sell{get;}
ISellDrugRepository SellDrug{get;}
IOrderRepository Order{get;}
IDrugPharmacyRepository DrugPharmacy{get;}
IDrugRepository Drug{get;}
ICompanyRepository Company{get;}
IUserPharmacyRepository UserPharmacy{get;}
IPharmacyRepository Pharmacy{get;}

        
        INotificationRepository Notification { get; }
        
    }
}
