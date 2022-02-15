using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Results;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IHairdresserDbContext _context;
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public ServiceService(IHairdresserDbContext context, IMapper mapper, IEmployeeService employeeService)
        {
            _context = context;
            _mapper = mapper;
            _employeeService = employeeService;
        }

        public async Task<ServiceResult> CreateServiceAsync(ServiceDto serviceDto)
        {
            var service = _mapper.Map<Service>(serviceDto);

            await _context.Services.AddAsync(service);
            return await _context.SaveChangesAsync(new CancellationToken()) > 0
                ? ServiceResult.Success()
                : ServiceResult.Failure("Something went wrong");
        }

        public async Task<ServiceResult> UpdateServiceAsync(ServiceDto serviceDto)
        {
            var service = await _context.Services.FirstOrDefaultAsync(s => s.Id == serviceDto.Id);

            if (service == null)
                return ServiceResult.Failure("Service doesn't exist");

            _mapper.Map(serviceDto, service);

            _context.Services.Update(service);
            return await _context.SaveChangesAsync(new CancellationToken()) > 0
                ? ServiceResult.Success()
                : ServiceResult.Failure("Something went wrong");
        }

        public async Task<bool> ServiceExistsAsync(int serviceId) =>
            await _context.Services.AsNoTracking().FirstOrDefaultAsync(s => s.Id == serviceId) != null;

        public async Task<bool> EmployeeAssignedToServiceAsync(int employeeId, int serviceId)
            => await _context.Services.Where(service =>
                    service.Id == serviceId &&
                    service.EmployeeServices.Any(es => es.EmployeeId == employeeId))
                .AnyAsync();

        public async Task<ServiceDto> GetServiceDtoByIdAsync(int id)
        {
            var service = await _context.Services.AsNoTracking().SingleOrDefaultAsync(service => service.Id == id);
            return service == null ? null : _mapper.Map<ServiceDto>(service);
        }

        public async Task<IEnumerable<ServiceDto>> GetServicesDtoAsync()
        {
            var services = await _context.Services.AsNoTracking().ToListAsync();

            if (!services.Any())
                return null;

            var servicesDto = new List<ServiceDto>();

            foreach (var service in services)
            {
                var serviceDto = _mapper.Map<ServiceDto>(service);
                await AddEmployeesToServiceDto(serviceDto);
                servicesDto.Add(serviceDto);
            }

            return servicesDto;
        }

        public async Task<ServiceDto> GetServiceDtoByNameAsync(string name)
        {
            var service = await _context.Services.AsNoTracking().FirstOrDefaultAsync(s => s.Name == name);

            if (service == null)
                return null;

            var serviceDto = _mapper.Map<ServiceDto>(service);
            await AddEmployeesToServiceDto(serviceDto);

            return serviceDto;
        }

        private async Task AddEmployeesToServiceDto(ServiceDto serviceDto)
        {
            var serviceEmployees = await _context.EmployeeService
                .AsNoTracking()
                .Where(e => e.ServiceId == serviceDto.Id)
                .ToListAsync();

            if (serviceEmployees.Any())
                serviceDto.EmployeeIds = serviceEmployees.Select(x => x.EmployeeId);
        }
    }
}