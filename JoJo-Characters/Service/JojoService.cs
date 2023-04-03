// using System.Text.Json;
// using JoJo_Characters.Models;

// namespace JoJo_Characters.Services;

// public class JojoService : IJojoService
// {
//     private readonly IHttpContextAccessor _session;
//     private readonly string personagensFile = @"Data\personagens.json";
//     private readonly string temporadasFile = @"Data\temporadas.json";
//     public JojoService(IHttpContextAccessor session)
//     {
//         _session = session;
//         PopularSessao();
//     }
//     public List<Personagem> GetPersonagens()
//     {
//         PopularSessao();
//         var personagens = JsonSerializer.Deserialize<List<Personagem>>
//         (_session.HttpContext.Session.GetString("Personagens"));
//         return personagens;
//     }
//     public List<Parte> GetPartes()
//     {
//         PopularSessao();
//         var partes = JsonSerializer.Deserialize<List<Parte>>
//         (_session.HttpContext.Session.GetString("Partes"));
//         return partes;
//     }
//     public Pokemon GetPokemon(int Numero)
//     {
//         var pokemons = GetPokemons();
//         return pokemons.Where(p => p.Numero == Numero).FirstOrDefault();
//     }
//     public PokedexDto GetPokedexDto()
//     {
//         var pokes = new PokedexDto()
//         {
//             Pokemons = GetPokemons(),
//             Tipos = GetTipos()
//         };
//         return pokes;
//     }
//     public DetailsDto GetDetailedPokemon(int Numero)
//     {
//         var pokemons = GetPokemons();
//         var poke = new DetailsDto()
//         {
//             Current = pokemons.Where(p => p.Numero == Numero)
//         .FirstOrDefault(),
//             Prior = pokemons.OrderByDescending(p => p.Numero)
//         .FirstOrDefault(p => p.Numero < Numero),
//             Next = pokemons.OrderBy(p => p.Numero)
//         .FirstOrDefault(p => p.Numero > Numero),
//         };
//         return poke;
//     }
//     public Tipo GetTipo(string Nome)
//     {
//         var tipos = GetTipos();
//         return tipos.Where(t => t.Nome == Nome).FirstOrDefault();
//     }
//     private void PopularSessao()
//     {
//         if (string.IsNullOrEmpty(_session.HttpContext.Session.GetString("Tipos")))
//         {
//             _session.HttpContext.Session
//             .SetString("Pokemons", LerArquivo(pokemonFile));
//             _session.HttpContext.Session
//             .SetString("Tipos", LerArquivo(tiposFile));
//         }
//     }
//     private string LerArquivo(string fileName)
//     {
//         using (StreamReader leitor = new StreamReader(fileName))
//         {
//             string dados = leitor.ReadToEnd();
//             return dados;
//         }
//     }
// }
