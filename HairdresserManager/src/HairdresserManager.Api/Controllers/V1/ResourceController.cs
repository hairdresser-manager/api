using HairdresserManager.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HairdresserManager.Api.Controllers.V1
{
    [ApiController]
    public class ResourceController : MainController
    {
        private readonly IResourcesService _resourceService;
        
        public ResourceController(IResourcesService resourceService)
        {
            _resourceService = resourceService;
        }
        
        
    }
}