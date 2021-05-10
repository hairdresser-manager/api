using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Results;

namespace ApplicationCore.Interfaces
{
    public interface IServiceService
    {
        Task<ServiceDto> GetServiceDtoByNameAsync(string name);
        Task<IEnumerable<ServiceDto>> GetServicesDtoAsync();
        Task<Result> CreateServiceAsync(ServiceDto serviceDto);
        Task<Result> UpdateServiceAsync(ServiceDto serviceDto);
        Task<bool> ServiceExistsAsync(int serviceId);
    }
}