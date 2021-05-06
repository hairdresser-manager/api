using System.Reflection;
using ApplicationCore.Interfaces;
using Infrastructure.Data;
using Infrastructure.Identity;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<HairdresserDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services
                .AddIdentity<User, Role>(options =>
                    options.User.RequireUniqueEmail = true)
                .AddEntityFrameworkStores<HairdresserDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IHairdresserDbContext>(provider => provider.GetService<HairdresserDbContext>());
            
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IIdentityService, IdentityService>();
            
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}