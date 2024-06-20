using System.Text.Json.Nodes;
using AutoMapper;
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Entities;
using GaragesStructure.DATA.DTOs.roles;
using GaragesStructure.DATA.DTOs.User;
using GaragesStructure.Entities;
using GaragesStructure.Entities.Company;
using GaragesStructure.Entities.UserPharmacy;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OneSignalApi.Model;

// here to implement


namespace GaragesStructure.Helpers
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {

            CreateMap<AppUser, UserDto>();
            CreateMap<RegisterForm, App>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateUserForm, AppUser>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Role, RoleDto>();
            CreateMap<AppUser, AppUser>();

            CreateMap<Permission, PermissionDto>();



            // here to add
CreateMap<Dept, DeptDto>();
CreateMap<DeptForm,Dept>();
CreateMap<DeptUpdate,Dept>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
CreateMap<Sell, SellDto>();
CreateMap<SellForm,Sell>();
CreateMap<SellUpdate,Sell>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
CreateMap<SellDrug, SellDrugDto>();
CreateMap<SellDrugForm,SellDrug>();
CreateMap<SellDrugUpdate,SellDrug>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
CreateMap<Order, OrderDto>();
CreateMap<OrderForm,Order>();
CreateMap<OrderUpdate,Order>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
CreateMap<DrugPharmacy, DrugPharmacyDto>();
CreateMap<DrugPharmacyForm,DrugPharmacy>();
CreateMap<DrugPharmacyUpdate,DrugPharmacy>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
CreateMap<Drug, DrugDto>();
CreateMap<DrugForm,Drug>();
CreateMap<DrugUpdate,Drug>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
CreateMap<Company, CompanyDto>();
CreateMap<CompanyForm,Company>();
CreateMap<CompanyUpdate,Company>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
CreateMap<UserPharmacy, UserPharmacyDto>();
CreateMap<UserPharmacyForm,UserPharmacy>();
CreateMap<UserPharmacyUpdate,UserPharmacy>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
CreateMap<Pharmacy, PharmacyDto>();
CreateMap<PharmacyForm,Pharmacy>();
CreateMap<PharmacyUpdate,Pharmacy>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}
