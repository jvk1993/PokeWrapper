using PokeWrapperService.Models;
using PokeWrapperService.Repositories;
using PokeWrapperService.Repositories.interfaces;
using PokeWrapperService.Services;
using PokeWrapperService.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSingleton<IPokemonRepository, PokemonRepository>();
builder.Services.AddHttpClient<IPokeAPIService, PokeAPIService>(options =>
{
    options.BaseAddress = new("https://pokeapi.co/api/v2/");
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/pokemon/{id}", async (int id, IPokemonRepository pokemonRepository) =>
{
    Pokemon? pokemon = await pokemonRepository.GetPokemonById(id);
    return pokemon is null ? Results.NotFound() : Results.Ok(pokemon);
}).WithName("GetPokemonById");

app.Run();