using System;
using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Services
{
    public class ClientService : IClientService
    {
        private readonly IHairdresserDbContext _context;

        public ClientService(IHairdresserDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddUserToClientsAsync(Guid userId)
        {
            var client = new Client {UserId = userId};
            await _context.Clients.AddAsync(client);
            return await _context.SaveChangesAsync(new CancellationToken()) > 0;
        }
    }
}