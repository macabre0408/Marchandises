using Marchandises.Models;
using System.ComponentModel;

namespace Marchandises.Services
{
    public interface IClientCrud
    {
        public Task<List<Client>> ShowClient();

        public Task<bool> InsertClient(Client cl);

        public Task UpdateClient(Client cl);

        public bool DeleteClient(int id);

        public Task<Client?> GetClient(int id);
    }
}
