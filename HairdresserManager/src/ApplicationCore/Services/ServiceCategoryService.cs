using System.Collections.Generic;
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
    public class ServiceCategoryService : IServiceCategoryService
    {
        private readonly IHairdresserDbContext _context;
        private readonly IMapper _mapper;

        public ServiceCategoryService(IHairdresserDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result> CreateCategoryAsync(string name)
        {
            var category = await _context.ServicesCategories.FirstOrDefaultAsync(s => s.Name.Equals(name));

            if (category != null)
                return Result.Failure("Category already exists");

            var newServicesCategory = new ServicesCategory {Name = name};

            await _context.ServicesCategories.AddAsync(newServicesCategory);
            return await _context.SaveChangesAsync(new CancellationToken()) > 0
                ? Result.Success()
                : Result.Failure("Something went wrong");
        }

        public async Task<IEnumerable<ServicesCategoryDto>> GetServicesCategoriesDtoAsync()
        {
            var categories = await _context.ServicesCategories.ToListAsync();
            return _mapper.Map<IEnumerable<ServicesCategoryDto>>(categories);
        }

        public async Task<Result> UpdateServicesCategoryAsync(int id, string name)
        {
            var serviceCategory = new ServicesCategory {Id = id, Name = name};

            _context.ServicesCategories.Update(serviceCategory);
            return await _context.SaveChangesAsync(new CancellationToken()) > 0
                ? Result.Success()
                : Result.Failure("Something went wrong");
        }

        public async Task<ServicesCategoryDto> GetServicesCategoryDtoByIdAsync(int id)
        {
            var servicesCategory =
                await _context.ServicesCategories.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
            return _mapper.Map<ServicesCategoryDto>(servicesCategory);
        }
    }
}