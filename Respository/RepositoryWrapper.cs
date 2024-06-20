using AutoMapper;
using BackEndStructuer.Interface;
using BackEndStructuer.Repository;
using GaragesStructure.DATA;
using GaragesStructure.Interface;

namespace GaragesStructure.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        private IUserRepository _user;
        private IPermissionRepository _permission;
        private IRoleRepository _role;

        public IRoleRepository Role
        {
            get
            {
                if (_role == null)
                {
                    _role = new RoleRepository(_context, _mapper);
                }

                return _role;
            }
        }

        public IPermissionRepository Permission
        {
            get
            {
                if (_permission == null)
                {
                    _permission = new PermissionRepository(_context, _mapper);
                }

                return _permission;
            }
        }

        

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_context, _mapper);
                }

                return _user;
            }
        }


        public RepositoryWrapper(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // here to add
private IDeptRepository _Dept;

public IDeptRepository Dept {
    get {
        if(_Dept == null) {
            _Dept = new DeptRepository(_context, _mapper);
        }
        return _Dept;
    }
}
private ISellRepository _Sell;

public ISellRepository Sell {
    get {
        if(_Sell == null) {
            _Sell = new SellRepository(_context, _mapper);
        }
        return _Sell;
    }
}
private ISellDrugRepository _SellDrug;

public ISellDrugRepository SellDrug {
    get {
        if(_SellDrug == null) {
            _SellDrug = new SellDrugRepository(_context, _mapper);
        }
        return _SellDrug;
    }
}
private IOrderRepository _Order;

public IOrderRepository Order {
    get {
        if(_Order == null) {
            _Order = new OrderRepository(_context, _mapper);
        }
        return _Order;
    }
}
private IDrugPharmacyRepository _DrugPharmacy;

public IDrugPharmacyRepository DrugPharmacy {
    get {
        if(_DrugPharmacy == null) {
            _DrugPharmacy = new DrugPharmacyRepository(_context, _mapper);
        }
        return _DrugPharmacy;
    }
}
private IDrugRepository _Drug;

public IDrugRepository Drug {
    get {
        if(_Drug == null) {
            _Drug = new DrugRepository(_context, _mapper);
        }
        return _Drug;
    }
}
private ICompanyRepository _Company;

public ICompanyRepository Company {
    get {
        if(_Company == null) {
            _Company = new CompanyRepository(_context, _mapper);
        }
        return _Company;
    }
}
private IUserPharmacyRepository _UserPharmacy;

public IUserPharmacyRepository UserPharmacy {
    get {
        if(_UserPharmacy == null) {
            _UserPharmacy = new UserPharmacyRepository(_context, _mapper);
        }
        return _UserPharmacy;
    }
}
private IPharmacyRepository _Pharmacy;

public IPharmacyRepository Pharmacy {
    get {
        if(_Pharmacy == null) {
            _Pharmacy = new PharmacyRepository(_context, _mapper);
        }
        return _Pharmacy;
    }
}

        
        private INotificationRepository _Notification;
        
        public INotificationRepository Notification
        {
            get
            {
                if (_Notification == null)
                {
                    _Notification = new NotificationRepository(_context, _mapper);
                }

                return _Notification;
            }
        }
        
    }
}
