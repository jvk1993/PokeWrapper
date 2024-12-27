using PokeWrapperService.Models.DTO;
using PokeWrapperService.Services.Interfaces;
using System.Text.Json;

namespace PokeWrapperService.Services
{
    public sealed class PokeAPIService(HttpClient httpClient) : IPokeAPIService
    {
        private const string UriSuffix = "pokemon/";
        private readonly JsonSerializerOptions jsonSerializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
        public async Task<PokemonDTO?> GetPokemonById(int id)
        {
            try
            {
                var response = await httpClient.GetFromJsonAsync(UriSuffix + id, typeof(PokemonDTO), jsonSerializerOptions);
                if (response is not null && response is PokemonDTO)
                {
                    return (PokemonDTO?)response;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
