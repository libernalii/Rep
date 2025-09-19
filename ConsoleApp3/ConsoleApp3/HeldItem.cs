using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class HeldItem
    {
        [JsonPropertyName("item")]
        public PokemonItems Item { get; set; }
    }
}
