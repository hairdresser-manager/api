using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Interfaces
{
    public interface IHairdresserDbContext
    {
        DbSet<Appointment> Appointments { get; set; }
        
        DbSet<Client> Clients { get; set; }
        
        DbSet<Employee> Employees { get; set; }
        
        DbSet<EmployeeRole> EmployeeRoles { get; set; }
        
        DbSet<EmployeesRole> EmployeesRoles { get; set; }
        
        DbSet<RefreshToken> RefreshTokens { get; set; }
        
        DbSet<Resource> Resources { get; set; }
        
        DbSet<ResourcesCategory> ResourcesCategories { get; set; }
        
        DbSet<Review> Reviews { get; set; }
        
        DbSet<Schedule> Schedules { get; set; }
        
        DbSet<Service> Services { get; set; }
        
        DbSet<ServiceCategory> ServiceCategories { get; set; }
        
        DbSet<ServiceEmployeeRole> ServiceEmployeeRoles { get; set; }
        
        DbSet<ServicesCategory> ServicesCategories { get; set; }
        
        DbSet<DayOff> DaysOff { get; set; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}