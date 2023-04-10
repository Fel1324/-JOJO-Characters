using JoJo_Characters.Models;
namespace JoJo_Characters.Services;

public interface IJojoService
{
    List<Personagem> GetPersonagens();
    List<Parte> GetPartes(); 
    Personagem GetPersonagem(string Nome);
    PersonagemDto GetPersonagemDto();
    DetailsDto GetDetailedPersonagem(string Nome);
    Parte GetParte(String Nome);
}