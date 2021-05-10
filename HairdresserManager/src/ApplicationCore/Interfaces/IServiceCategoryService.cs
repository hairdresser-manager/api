using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Results;

namespace ApplicationCore.Interfaces
{
    public interface IServiceCategoryService
    {
        Task<Result> CreateCategoryAsync(string name);
        Task<IEnumerable<ServicesCategoryDto>> GetServicesCategoriesDtoAsync();
        Task<Result> UpdateServicesCategoryAsync(int id, string name);
        Task<ServicesCategoryDto> GetServicesCategoryDtoByIdAsync(int id);
    }
}