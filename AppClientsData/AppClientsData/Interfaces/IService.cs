using AppClientsData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppClientsData.Interfaces
{
    public interface IService
    {
        Task AddClientAsync(Client client);
        Task<List<Client>> GetAllClientsAsync();
        Task<List<Client>> GetClientsByNameAsync(string name);
    }
}
