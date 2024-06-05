using Marchandises.Models;
using System.ComponentModel;

namespace Marchandises.Services
{
    public interface IClientCrud
    {
        public Task<List<Client>> ShowClient();

        public Task<bool> InsertClient(Client cl);

        public Task<bool> UpdateClient(Client cl);

        public Task DeleteClient(int id);

        public Task<Client?> GetClient(int id);
    }
}
