using System;
using System.Threading.Tasks;
using AppClientsData.Interfaces;
using AppClientsData.Models;
using AppClientsData.Services;

namespace AppClientsData
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IService clientService = new ClientService();

            while (true)
            {
                Console.WriteLine("\n=== Menu ===");
                Console.WriteLine("1 - Add client");
                Console.WriteLine("2 - Show all clients");
                Console.WriteLine("3 - Search client by name");
                Console.WriteLine("0 - Exit");

                Console.Write("Choose an option: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        await AddClientAsync(clientService);
                        break;
                    case "2":
                        await ShowAllClientsAsync(clientService);
                        break;
                    case "3":
                        await FindClientAsync(clientService);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private static async Task AddClientAsync(IService service)
        {
            Console.Write("Name: ");
            var name = Console.ReadLine();

            Console.Write("Surname: ");
            var surname = Console.ReadLine();

            Console.Write("Birthday (yyyy-mm-dd): ");
            DateTime bDay = Convert.ToDateTime(Console.ReadLine());

            Console.Write("City: ");
            var city = Console.ReadLine();

            Console.Write("Street: ");
            var street = Console.ReadLine();

            Console.Write("Build: ");
            int build = Convert.ToInt32(Console.ReadLine());

            Console.Write("Flat: ");
            var flatInput = Console.ReadLine();
            int? flat = string.IsNullOrWhiteSpace(flatInput) ? null : Convert.ToInt32(flatInput);

            var client = new Client
            {
                Name = name,
                Surname = surname,
                BDay = bDay,
                address = new Address
                {
                    City = city,
                    Street = street,
                    Build = build,
                    Flat = flat
                }
            };

            await service.AddClientAsync(client);
        }

        private static async Task ShowAllClientsAsync(IService service)
        {
            var clients = await service.GetAllClientsAsync();
            if (clients.Count == 0)
            {
                Console.WriteLine("Client not found.");
                return;
            }

            foreach (var client in clients)
            {
                Console.WriteLine($"{client.Name} {client.Surname}, b-day: {client.BDay:yyyy-MM-dd}, " + $"address: {client.address.City}, {client.address.Street} {client.address.Build}" + $"{(client.address.Flat.HasValue ? $"/{client.address.Flat}" : "")}");
            }
        }

        private static async Task FindClientAsync(IService service)
        {
            Console.Write("Enter name for searched: ");
            var name = Console.ReadLine();
            var clients = await service.GetClientsByNameAsync(name);

            if (clients.Count == 0)
            {
                Console.WriteLine("Client not found.");
                return;
            }

            foreach (var client in clients)
            {
                Console.WriteLine($"{client.Name} {client.Surname}, birthday: {client.BDay:yyyy-MM-dd}, " + $"address: {client.address.City}, {client.address.Street} {client.address.Build}" + $"{(client.address.Flat.HasValue ? $"/{client.address.Flat}" : "")}");
            }
        }
    }
}
