using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1.Admin
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    [ApiExplorerSettings(GroupName = "Admin / Employees / Summaries")]
    public class EmployeeSummariesController : ControllerBase
    {
        
    }
}