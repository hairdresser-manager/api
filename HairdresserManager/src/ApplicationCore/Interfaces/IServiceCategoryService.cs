using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Results;

namespace ApplicationCore.Interfaces
{
    public interface IServiceCategoryService
    {
        Task<ServiceResult> CreateCategoryAsync(string name);
        Task<IEnumerable<ServicesCategoryDto>> GetServicesCategoriesDtoAsync();
        Task<ServiceResult> UpdateServicesCategoryAsync(int id, string name);
        Task<ServicesCategoryDto> GetServicesCategoryDtoByIdAsync(int id);
    }
}