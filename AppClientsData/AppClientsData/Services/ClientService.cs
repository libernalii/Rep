using AppClientsData.Interfaces;
using AppClientsData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppClientsData.Services
{
    public class ClientService : IService
    {
        private readonly string _filePath = "clients.json";
        public async Task AddClientAsync(Client client)
        {
            var clients = await GetAllClientsAsync();
            clients.Add(client);
            await SaveClientsAsync(clients);
        }

        public async Task<List<Client>> GetAllClientsAsync()
        {
            if (!File.Exists(_filePath))
                return new List<Client>();

            string json = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<List<Client>>(json) ?? new List<Client>();
        }

        public async Task<List<Client>> GetClientsByNameAsync(string name)
        {
            var clients = await GetAllClientsAsync();
            return clients.FindAll(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        private async Task SaveClientsAsync(List<Client> clients)
        {
            var json = JsonSerializer.Serialize(clients, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_filePath, json);
        }
    }
}
