using PokeWrapperService.Models;

namespace PokeWrapperService.Repositories.interfaces
{
    public interface IPokemonRepository
    {
        Task<Pokemon?> GetPokemonById(int id);
        Task<Pokemon?> GetPokemonByName(string name);
    }
}
