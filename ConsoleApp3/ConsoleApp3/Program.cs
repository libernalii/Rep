using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Random rnd = new Random();
            var httpClient = new HttpClient();
            string uri = "https://pokeapi.co/api/v2/";
            httpClient.BaseAddress = new Uri(uri);
            var response = await httpClient.GetAsync("pokemon/" + rnd.Next(1, 1200) + "/");
            var content = await response.Content.ReadAsStringAsync();
            var pokemon = System.Text.Json.JsonSerializer.Deserialize<Pokemon>(content);
            Console.WriteLine($"Id - {pokemon.Id}\nName - {pokemon.Name}\nHeight - {pokemon.Height}\nSpecies: \nName - {pokemon.Species.Name}\nstats:");
            for (int i = 0; i < pokemon.Stats.Count; i++)
            {
                Console.WriteLine($"[{i}] \nBaseStat - {pokemon.Stats[i].BaseStat} \nEffort - {pokemon.Stats[i].Effort} \nStat: \nName - {pokemon.Stats[i].Stat.Name}");
            }
            for (int i = 0; i < pokemon.HeldItems.Length; i++)
            {
                Console.WriteLine($"HeldItems: \nItem[{i}] - \nName {pokemon.HeldItems[i].Item.Name}\nUrl {pokemon.HeldItems[i].Item.Url}");
            }



            if (pokemon.HeldItems.Length!=0) 
            {
                string str = pokemon.HeldItems[0].Item.Url.Replace(uri, "");
                response = await httpClient.GetAsync(str);
                content = await response.Content.ReadAsStringAsync();
                var aboutItem = System.Text.Json.JsonSerializer.Deserialize<AllAboutItem>(content);
                Console.WriteLine($"Id - {aboutItem.Id}\nName - {aboutItem.Name}\nCost - {aboutItem.Cost}");

            }
                Console.ReadLine();

        }
    }
}
