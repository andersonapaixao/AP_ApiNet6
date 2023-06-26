using AP_ApiNet6.Application.Mappings;
using AP_ApiNet6.Application.Services;
using AP_ApiNet6.Application.Services.Interfaces;
using AP_ApiNet6.Domain.Authentication;
using AP_ApiNet6.Domain.Integrations;
using AP_ApiNet6.Domain.Repositories;
using AP_ApiNet6.Infra.Data.Authentication;
using AP_ApiNet6.Infra.Data.Context;
using AP_ApiNet6.Infra.Data.Integrations;
using AP_ApiNet6.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace AP_ApiNet6.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                         options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPersonImageRepository, PersonImageRepository>();
            services.AddScoped<ISavePersonImage, SavePersonImage>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDtoMapping));
            
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPurchaseService, PurchaseService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPersonImageService, PersonImageService>();

            return services;
        }
    }
}
