using hw4_la.Interfaces;
using hw4_la.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4_la.Services
{
    public class ClientService : IClientService
    {
        public Task<Client> AddClientAsync(string path, Client client)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"#####\n{client.name}>{client.BirthDay}>{client.address.city}>{client.address.street}>{client.address.HouseNumber}>");
            }
            return Task.FromResult(client);
        }

        public async Task<IEnumerable<Client>> GetAllAsync(string path)
        {
            List<Client> client = new List<Client>();
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLineAsync().Result) != null)
                {
                    if (line != null && line != "#####")
                    {
                        string[] parts = line.Split('>');
                        Client c = new Client
                        {
                            name = parts[0],
                            BirthDay = DateTime.Parse(parts[1]),
                            address = new Address
                            {
                                city = parts[2],
                                street = parts[3],
                                HouseNumber = Convert.ToInt32(parts[4])
                            }
                        };
                        client.Add(c);
                    }
                }
            }
            return client;
        }

        public Task<Client> GetByNameAsync(string name, string path)
        {
            Client client = new Client();
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLineAsync().Result) != null)
                {
                    string[] parts = line.Split('>');
                    if (parts[0] == name)
                        client = new Client
                        {
                            name = parts[0],
                            BirthDay = DateTime.Parse(parts[1]),
                            address = new Address
                            {
                                street = parts[3],
                                city = parts[2],
                                HouseNumber = int.Parse(parts[4])
                            }
                        };
                }
            }
            return Task.FromResult(client);
        }
    }
}
