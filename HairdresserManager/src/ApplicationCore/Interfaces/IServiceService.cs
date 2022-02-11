using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Results;

namespace ApplicationCore.Interfaces
{
    public interface IServiceService
    {
        Task<ServiceDto> GetServiceDtoByNameAsync(string name);
        Task<ServiceDto> GetServiceDtoByIdAsync(int id);
        Task<IEnumerable<ServiceDto>> GetServicesDtoAsync();
        Task<ServiceResult> CreateServiceAsync(ServiceDto serviceDto);
        Task<ServiceResult> UpdateServiceAsync(ServiceDto serviceDto);
        Task<bool> ServiceExistsAsync(int serviceId);
    }
}