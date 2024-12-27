using PokeWrapperService.Models.DTO;

namespace PokeWrapperService.Services.Interfaces
{
    public interface IPokeAPIService
    {
        Task<PokemonDTO?> GetPokemonById(int id);
    }
}
