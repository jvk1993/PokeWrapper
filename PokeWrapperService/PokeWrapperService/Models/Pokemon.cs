using PokeWrapperService.Models.DTO;

namespace PokeWrapperService.Models
{
    public sealed class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public Pokemon()
        {

        }
        public Pokemon(PokemonDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
        }
    }
}
