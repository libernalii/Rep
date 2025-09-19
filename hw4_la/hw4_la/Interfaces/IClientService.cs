using hw4_la.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4_la.Interfaces
{
    public interface IClientService
    {
        Task<Client> AddClientAsync(string path, Client client);
        Task<IEnumerable<Client>> GetAllAsync(string path);
        Task<Client> GetByNameAsync(string name, string path);
    }
}
