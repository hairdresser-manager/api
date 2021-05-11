using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IAppointmentService
    {
        Task<List<(string, List<string>)>> GetFreeFutureDatesForEmployeeAsync(int employeeId);
    }
}