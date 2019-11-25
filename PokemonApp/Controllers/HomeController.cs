using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonApp.Models;
using PokemonAppAPIConsumer; // add library reference to pokemon app project

namespace PokemonApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index(int? id)
        {

            // if no pokemon id is passed in then default to first pokemon.
            // Below is shorter syntax logic to using a if / else statement.
            // coelesce expression would be  == id ?? 1 to shorten below statement even more.
            int pokemonId = (id.HasValue) ? id.Value : 1;
            
            

            PokemonClient client = new PokemonClient();
            PokemonResponse data = await client.GetPokemonAsync(pokemonId);

            var pokemon = new SinglePokedexEntry
            {
                PokedexId = data.id,
                Weight = data.weight,
                Height = data.height,
                ProfileImageUrl = data.sprites.front_default,
                Name = data.name,
                Abilities = new List<string>()
            };

            foreach(var currentAbility in data.abilities)
            {
                pokemon.Abilities.Add(currentAbility.ability.name);
            }


            return View(pokemon);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
