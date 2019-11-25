using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokemonAppAPIConsumer
{
    public class PokemonClient
    {
        private static readonly HttpClient _client;


        // static construcor so all Pokemon clients can use this class.
        static PokemonClient()
        {
            _client = new HttpClient();

            // Get base address from PokemonAPI
            _client.BaseAddress = new Uri("https://pokeapi.co//api/v2/");
        }

        /// <summary>
        /// Returns a single pokemon data using the id or name if both are supplied then id will be used.
        /// </summary>
        /// <returns></returns>
        public async Task<PokemonResponse> GetPokemonAsync(int id)
        {
            HttpResponseMessage response = await _client.GetAsync($"pokemon/{id}");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                PokemonResponse result = JsonConvert.DeserializeObject<PokemonResponse>(data);
                return result;
            }

            else 
            {
                throw new ArgumentNullException($"{nameof(id)} must be supplied.");
            }
            

            


        }

        /// <summary>
        /// Returns a single Pokemons data using name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<PokemonResponse> GetPokemon(string name)
        {

            HttpResponseMessage response = await _client.GetAsync($"pokemon/{name}");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                PokemonResponse result = JsonConvert.DeserializeObject<PokemonResponse>(data);
                return result;
            }

            else
            {
                throw new ArgumentNullException($"{nameof(name)} must be supplied.");
            }
            
        }
    }
}
