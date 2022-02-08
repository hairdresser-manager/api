using System;
using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<int> GetClientIdByUserId(Guid userId)
        {
            var client = await _context.Clients.SingleOrDefaultAsync(client => client.UserId == userId);
            return client?.Id ?? 0;
        }
    }
}