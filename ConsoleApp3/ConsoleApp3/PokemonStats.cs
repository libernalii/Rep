using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class PokemonStats
    {
        [JsonPropertyName("base_stat")]
        public int BaseStat { get; set; }
        [JsonPropertyName("effort")]
        public int Effort { get; set; }
        [JsonPropertyName("stat")]
        public Stat Stat { get; set; }
    }
}
