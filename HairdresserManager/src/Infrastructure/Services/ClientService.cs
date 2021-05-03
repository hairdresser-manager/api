using System;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Services
{
    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext _context;

        public ClientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddUserToClientAsync(Guid userId)
        {
            var client = new Client {UserId = userId};
            await _context.Clients.AddAsync(client);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}