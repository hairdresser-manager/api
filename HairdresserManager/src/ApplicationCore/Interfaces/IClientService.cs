using System;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IClientService
    {
        Task<bool> AddUserToClientsAsync(Guid userId);
    }
}