using AutoMapper;
using BackEndStructuer.Services;
using e_parliament.Interface;
using Microsoft.EntityFrameworkCore;
using GaragesStructure.DATA;
using GaragesStructure.Helpers;
using GaragesStructure.Repository;
using GaragesStructure.Services;

using Hangfire;
using Hangfire.MemoryStorage;
using Hangfire.PostgreSql;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using RestSharp;

namespace GaragesStructure.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseNpgsql(config.GetConnectionString("DefaultConnection")));


            services.AddFluentValidationRulesToSwagger();


            services.AddHangfire((sp, config) =>
            {
                var connection = sp.GetRequiredService<IConfiguration>().GetConnectionString("DefaultConnection");
                config.UsePostgreSqlStorage(connection);
            });


            services.AddAutoMapper(typeof(UserMappingProfile).Assembly);
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<AuthorizeActionFilter>();


            // here to add
services.AddScoped<IDeptServices, DeptServices>();
services.AddScoped<ISellServices, SellServices>();
services.AddScoped<ISellDrugServices, SellDrugServices>();
services.AddScoped<IOrderServices, OrderServices>();
services.AddScoped<IDrugPharmacyServices, DrugPharmacyServices>();
services.AddScoped<IDrugServices, DrugServices>();
services.AddScoped<ICompanyServices, CompanyServices>();
services.AddScoped<IUserPharmacyServices, UserPharmacyServices>();
services.AddScoped<IPharmacyServices, PharmacyServices>();
       
            services.AddScoped<IFileService, FileService>();
           

            services.AddScoped<PermissionSeeder>();
            services.AddScoped<RoleSeeder>();
            services.AddScoped<DatabaseSeeder>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IOtpCodeServices, OtpCodeServices>();
            services.AddScoped<INotificationProvider, NotificationProvider>();
            services.AddScoped<IRestClient, RestClient>();
            services.AddScoped<IRestRequest, RestRequest>();
            
            
            // seed data from permission seeder service

            var serviceProvider = services.BuildServiceProvider();
        

            var permissionSeeder = serviceProvider.GetService<PermissionSeeder>();
            //permissionSeeder.SeedPermissions();

       //     var roles = serviceProvider.GetService<RoleSeeder>();
       //     roles.AddRole();
       //     var seeds =  serviceProvider.GetService<DatabaseSeeder>();
       //     seeds.SeedData();


            return services;
        }
    }
}
