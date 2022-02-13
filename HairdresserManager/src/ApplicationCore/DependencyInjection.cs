using System.Reflection;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.Extensions.DependencyInjection;
using EmployeeService = ApplicationCore.Services.EmployeeService;

namespace ApplicationCore
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IServiceCategoryService, ServiceCategoryService>();
            services.AddScoped<IServiceEmployeeService, ServiceEmployeeService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IRefreshTokenService, RefreshTokenService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IJwtManager, JwtManager>();
            
            return services;
        }
    }
}