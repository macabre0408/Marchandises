using Marchandises.Data;
using Marchandises.Models;
using Microsoft.EntityFrameworkCore;


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
        public async Task DeleteClient(int id)
        {
            Client? cl = _context.Clients.Find(id);
            if (cl != null)
            {
                _context.Clients.Remove(cl);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Client?> GetClient(int id)
        {
            return await _context.Clients.FindAsync(id);

        }

        public async Task<bool> InsertClient(Client cl)
        {
            // Vérification que le nom et le téléphone ne sont pas null ou vides
            if (string.IsNullOrWhiteSpace(cl.Nom) || string.IsNullOrWhiteSpace(cl.Telephone))
            {
                return false;
            }

            // Vérification si un client avec le même nom et téléphone existe déjà
            bool clientExists = await _context.Clients
                                              .AnyAsync(c => c.Nom == cl.Nom && c.Telephone == cl.Telephone);

            if (!clientExists)
            {
                // Ajouter le nouveau client au contexte
                _context.Clients.Add(cl);
                try
                {
                    // Sauvegarder les changements dans la base de données
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    // Enregistrer l'erreur (décommenter si un logger est disponible)
                    //_logger.LogError(ex.Message);
                    return false;
                }
            }

            return false; // Retourne false si le client existe déjà
        }


        async Task<List<Client>> IClientCrud.ShowClient()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<bool> UpdateClient(Client client)
        {
            var existingClient = await _context.Clients.FindAsync(client.Id);
            if (existingClient == null)
            {
                return false;
            }

            existingClient.Nom = client.Nom;
            existingClient.Telephone = client.Telephone;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log error (ex.Message)
                return false;
            }
        }

    }
}
