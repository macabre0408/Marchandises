using Marchandises.Data;
using Marchandises.Models;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;


namespace Marchandises.Services
{
    public class ClientCrud : IClientCrud
    {
        private readonly ProductDbContext _context;

        private readonly ILogger<Client>? _logger;

        public ClientCrud(ProductDbContext context)
        {
            _context = context;
        }
        public bool DeleteClient(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Client?> GetClient(int id)
        {
            return await _context.Clients.FindAsync(id);
            
        }

        async Task<bool> IClientCrud.InsertClient(Client cl)
        {
            if (string.IsNullOrWhiteSpace(cl.Nom) || string.IsNullOrWhiteSpace(cl.Telephone))
            {
                return false;
            }
            else
            {
                _context.Clients.Add(cl);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex) { 
                    //_logger.LogError(ex.Message);
                    return false;
                }
                return true;
            }
        }

        async Task<List<Client>> IClientCrud.ShowClient()
        {
               return await _context.Clients.ToListAsync();
        }

        public async Task UpdateClient(Client cl)
        {
            _context.Entry(cl).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
    }
}
