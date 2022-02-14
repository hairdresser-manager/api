using ApplicationCore.Contract.V1.General.Responses;
using ApplicationCore.Helpers;
using AutoMapper;

namespace ApplicationCore.Mapping
{
    public class HelperToResponseProfile : Profile
    {
        public HelperToResponseProfile()
        {
            CreateMap<PaginationHelper, PaginationMetadataResponse>();
        }
    }
}