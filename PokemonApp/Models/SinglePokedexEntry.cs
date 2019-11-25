using PokemonAppAPIConsumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonApp.Models
{
    /// <summary>
    /// ViewModel class for displaying a single Pokemon's PokeDex entry.
    /// </summary>
    public class SinglePokedexEntry
    {
        public int PokedexId { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

        // List of Pokemon's ability name
        public List<string> Abilities { get; set; }
    }
}
