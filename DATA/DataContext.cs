using System.Reflection;
using BackEndStructuer.Entities;
using GaragesStructure.DATA.DTOs;
using GaragesStructure.Entities;
using GaragesStructure.Entities.Company;
using GaragesStructure.Entities.UserPharmacy;
using GaragesStructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace GaragesStructure.DATA
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


        public DbSet<AppUser> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }


        // here to add
public DbSet<Dept> Depts { get; set; }
        public DbSet<Sell> Sells { get; set; }
        public DbSet<SellDrug> SellDrugs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<DrugPharmacy> DrugPharmacys { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<UserPharmacy> UserPharmacys { get; set; }
        public DbSet<Pharmacy> Pharmacys { get; set; }
        public DbSet<LoginLogger> LoginLoggers { get; set; }


        public DbSet<Notifications> Notifications { get; set; }

        // public DbSet<DriverVehicle> DriverVehicles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RolePermission>().HasKey(rp => new { rp.RoleId, rp.PermissionId });
            modelBuilder.Entity<UserPharmacy>().HasKey(e =>
                new
                {
                    e.UserId, e.PharmacyId
                });

            modelBuilder.Entity<UserPharmacy>().HasOne(e => e.User)
                .WithMany(p => p.UserPharmacies)
                .HasForeignKey(e => e.UserId);
            modelBuilder.Entity<UserPharmacy>().HasOne(e => e.Pharmacy)
                .WithMany(e => e.UserPharmacies)
                .HasForeignKey(e => e.PharmacyId);
            modelBuilder.Entity<DrugPharmacy>().HasOne(e => e.Drug).WithMany(e => e.DrugPharmacies)
                .HasForeignKey(e => e.DrugId);
            modelBuilder.Entity<Drug>().HasOne<Company>(e=> e.Company).WithMany(e=> e.Drugs).HasForeignKey(e=> e.CompanyId);
            modelBuilder.Entity<Order>().HasOne(e => e.User).WithMany(e => e.Orders).HasForeignKey(e => e.UserId);
            modelBuilder.Entity<DrugPharmacy>().HasOne<Order>(e=>e.Order).WithMany(e=>e.DrugPharmacies).HasForeignKey(e=>e.OrderId);
            modelBuilder.Entity<Order>().HasOne<Pharmacy>(e=>e.Pharmacy).WithMany(e=>e.Orders).HasForeignKey(e=>e.PharmacyId);
            modelBuilder.Entity<SellDrug>().HasOne<DrugPharmacy>(e=>e.DrugPharmacy).WithMany(e=>e.SellDrugs).HasForeignKey(e=>e.DrugPharmacyId);
            modelBuilder.Entity<SellDrug>().HasOne<Sell>(e=>e.Sell).WithMany(e=>e.SellDrugs).HasForeignKey(e=>e.SellId);
            modelBuilder.Entity<Sell>().HasOne<Pharmacy>(e => e.Pharmacy).WithMany(e => e.Sells)
                .HasForeignKey(e => e.PharmacyId);
            modelBuilder.Entity<Sell>().HasOne<AppUser>(e => e.User).WithMany(e => e.Sells)
                .HasForeignKey(e => e.UserId);
            modelBuilder.Entity<Sell>().HasOne<Dept>(e => e.Dept).WithMany(e => e.Sells).HasForeignKey(e => e.DeptId);
            seedData(modelBuilder);
                            
            // new DbInitializer(modelBuilder).Seed();
            //     Guid pharmacyId = Guid.NewGuid();
            //     Guid userId = Guid.NewGuid();
            //     modelBuilder.Entity<Pharmacy>().HasData(new List<Pharmacy>([new Pharmacy
            //   {
            //     Id = pharmacyId,
            //   Name = "any"
            //}]));

        }



        public virtual async Task<int> SaveChangesAsync(Guid? userId = null)
        {
            // await OnBeforeSaveChanges(userId);
            var result = await base.SaveChangesAsync();
            return result;
        }

        // private async Task OnBeforeSaveChanges(Guid? userId)
        // {
        //     try
        //     {
        //         ChangeTracker.DetectChanges();
        //
        //         var auditEntries = new List<AuditEntry>();
        //
        //         foreach (var entry in ChangeTracker.Entries()
        //                      .Where(e => e.Entity is not Audit &&
        //                                  (e.State is
        //                                      EntityState.Added or
        //                                      EntityState.Modified or
        //                                      EntityState.Deleted) &&
        //                                  e.Entity.GetType().GetCustomAttribute<AuditTrailAttribute>() != null))
        //         {
        //             var auditEntry = new AuditEntry(entry)
        //             {
        //                 TableName = entry.Metadata.GetTableName(),
        //                 UserId = userId
        //             };
        //
        //             foreach (var property in entry.Properties)
        //             {
        //                 if (property.Metadata.IsPrimaryKey())
        //                 {
        //                     auditEntry.KeyValues[property.Metadata.Name] = property.CurrentValue;
        //                     continue;
        //                 }
        //
        //                 if (entry.State == EntityState.Added)
        //                 {
        //                     auditEntry.AuditType = AuditType.Create;
        //                     auditEntry.NewValues[property.Metadata.Name] = property.CurrentValue;
        //                 }
        //                 else if (entry.State == EntityState.Deleted)
        //                 {
        //                     auditEntry.AuditType = AuditType.Delete;
        //                     auditEntry.OldValues[property.Metadata.Name] =
        //                         entry.GetDatabaseValues()[property.Metadata] ?? DBNull.Value;
        //                 }
        //
        //                 else if (entry.State == EntityState.Modified && property.IsModified)
        //                 {
        //                     auditEntry.AuditType = AuditType.Update;
        //                     auditEntry.OldValues[property.Metadata.Name] =
        //                         entry.GetDatabaseValues()[property.Metadata] ?? DBNull.Value;
        //                     auditEntry.NewValues[property.Metadata.Name] = property.CurrentValue;
        //                 }
        //             }
        //
        //             auditEntries.Add(auditEntry);
        //         }
        //
        //         var databaseValues = await Task.WhenAll(auditEntries
        //             .Where(e => e.AuditType != AuditType.Create)
        //             .Select(async entry => new
        //             {
        //                 Entry = entry,
        //                 DatabaseValues = await entry.Entry.GetDatabaseValuesAsync()
        //             }));
        //
        //         foreach (var item in databaseValues)
        //         {
        //             var auditEntry = item.Entry;
        //             foreach (var property in auditEntry.Entry.Properties)
        //             {
        //                 var propertyName = property.Metadata.Name;
        //                 if (!auditEntry.ChangedColumns.Contains(propertyName))
        //                     auditEntry.ChangedColumns.Add(propertyName);
        //
        //                 if (auditEntry.AuditType == AuditType.Delete)
        //                 {
        //                     auditEntry.OldValues[propertyName] = item.DatabaseValues[propertyName] ?? DBNull.Value;
        //                 }
        //             }
        //         }
        //
        //         var auditLogs = auditEntries
        //             .Select(auditEntry => auditEntry.ToAudit(
        //                 auditEntry.TableName,
        //                 auditEntry.Entry.OriginalValues.GetValue<Guid>("Id"),
        //                 DateTime.Now))
        //             .ToList();
        //
        //         await AuditLogs.AddRangeAsync(auditLogs);
        //     }
        //     catch (Exception e)
        //     {
        //         // Handle exceptions gracefully, log them appropriately
        //         Console.WriteLine("Exception during audit: " + e);
        //         throw;
        //     }
        // }
        private async void seedData(ModelBuilder modelBuilder)
        {
            Guid roleId = Guid.NewGuid();
            Guid permissionId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();
            Guid pharmacyId = Guid.NewGuid();
            Guid userPharmacy = Guid.NewGuid();
            Guid companyId = Guid.NewGuid();
            Guid drugId = Guid.NewGuid();
            Guid drugPharmacyId = Guid.NewGuid();
            Guid orderId = Guid.NewGuid();
            Guid sellId = Guid.NewGuid();
            Guid sellDrugId = Guid.NewGuid();
            Guid DeptId = Guid.NewGuid();
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = roleId,
                Name = "Super Admin"
            });
            modelBuilder.Entity<Permission>().HasData(new Permission
            {
                Id = permissionId,
                Action = "Super Admin",
                FullName = "super admin",
                Subject = "super admin",
            });
            modelBuilder.Entity<RolePermission>().HasData(new RolePermission
            {
                RoleId = roleId,
                PermissionId = permissionId
            });
            modelBuilder.Entity<AppUser>().HasData(new AppUser
                {
                    Id = userId,
                    Email = "bbbeat114@gmail.com",
                    FullName = "super admin",
                    IsActive = true,
                    Password = BCrypt.Net.BCrypt.HashPassword("12345678"),
                    RoleId = roleId
                }
            );
            modelBuilder.Entity<Pharmacy>().HasData(new Pharmacy
            {
                Id = pharmacyId,
                Name = "any"
            });
            modelBuilder.Entity<UserPharmacy>().HasData(new UserPharmacy
            {
                Id = userPharmacy,
                PharmacyId = pharmacyId,
                UserId = userId
            });
           
          modelBuilder.Entity<Company>().HasData(new Company
          {
              Id = companyId,
              Name = "any"
          });
            modelBuilder.Entity<Drug>().HasData(new Drug
            {
                Id = drugId,
                Name = "any",
                CompanyId= companyId,
                Description = "desc",
                Dose = 1000
                
            });
            
            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = orderId,
                UserId = userId,
                PharmacyId = pharmacyId
                
            });
            modelBuilder.Entity<DrugPharmacy>().HasData(new DrugPharmacy
            {
                Id = drugPharmacyId,
                DrugId = drugId,
                UnitPrice = 1000,
                ExpiryDate = new DateOnly(2024, 12, 12),
                Quantity = 100,
                OrderId = orderId
            });
            modelBuilder.Entity<Dept>().HasData(new Dept
            {
                Name = "ali",
                Value = 1000,
                Id = DeptId

            });
            modelBuilder.Entity<Sell>().HasData(new Sell
            {
                Id = sellId,
                UserId = userId,
                PharmacyId = pharmacyId,
                Discount = 1000,
                DeptId = DeptId
                
            });
            modelBuilder.Entity<SellDrug>().HasData(
                new SellDrug
                {
                    Id = sellDrugId,
                    DrugPharmacyId = drugPharmacyId,
                    SellId = sellId,
                    Quantity = 100
                }
            );
         
        }

    }
    }
