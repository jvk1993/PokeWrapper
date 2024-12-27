using PokeWrapperService.Models;
using PokeWrapperService.Models.DTO;
using PokeWrapperService.Repositories.interfaces;
using PokeWrapperService.Services.Interfaces;

namespace PokeWrapperService .Repositories
{
    public sealed class PokemonRepository(IPokeAPIService pokeAPIService) : IPokemonRepository
    {
        private readonly Dictionary<int, Pokemon> KnownPokemons = [];
        public async Task<Pokemon?> GetPokemonById(int id)
        {
            KnownPokemons.TryGetValue(id, out Pokemon? pokemon);
            if (pokemon is null)
            {
                Pokemon? newAddedPokemon = await GetNewPokemon(id);
                if(newAddedPokemon is not null)
                {
                    KnownPokemons.Add(id, newAddedPokemon);
                    pokemon = newAddedPokemon;
                }
            }
            return pokemon;
        }

        public Task<Pokemon?> GetPokemonByName(string name)
        {
            throw new NotImplementedException();
        }

        private async Task<Pokemon?> GetNewPokemon(int id)
        {
            PokemonDTO? pokemonDTO = await pokeAPIService.GetPokemonById(id);
            if(pokemonDTO is null)
            {
                return null;
            }
            return new Pokemon(pokemonDTO);
        }
    }
}
