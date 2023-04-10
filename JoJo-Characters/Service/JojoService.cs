using System.Text.Json;
using JoJo_Characters.Models;

namespace JoJo_Characters.Services;

public class JojoService : IJojoService
{
    private readonly IHttpContextAccessor _session;
    private readonly string personagensFile = @"Data\personagens.json";
    private readonly string temporadasFile = @"Data\temporadas.json";
    public JojoService(IHttpContextAccessor session)
    {
        _session = session;
        PopularSessao();
    }
    public List<Personagem> GetPersonagens()
    {
        PopularSessao();
        var personagens = JsonSerializer.Deserialize<List<Personagem>>
        (_session.HttpContext.Session.GetString("Personagens"));
        return personagens;
    }
    public List<Parte> GetPartes()
    {
        PopularSessao();
        var partes = JsonSerializer.Deserialize<List<Parte>>
        (_session.HttpContext.Session.GetString("Partes"));
        return partes;
    }
    public Personagem GetPersonagem(string Nome)
    {
        var personagens = GetPersonagens();
        return personagens.Where(p => p.Nome == Nome).FirstOrDefault();
    }
    public PersonagemDto GetPersonagemDto()
    {
        var perso = new PersonagemDto()
        {
            Personagens = GetPersonagens(),
            Partes = GetPartes()
        };
        return perso;
    }
    public DetailsDto GetDetailedPersonagem(string Nome)
    {
        var personagens = GetPersonagens().ToArray();
        var index = Array.IndexOf(personagens, personagens.Where(p => p.Nome.Equals(Nome)).FirstOrDefault());
        var perso = new DetailsDto()
        {
            Current = personagens[index],
            Prior = index - 1 < 0 ? null : personagens[index - 1],
            Next = index + 1 >= personagens.Count() ? null : personagens[index + 1]
        };
        return perso;
    }
    public Parte GetParte(string Nome)
    {
        var partes = GetPartes();
        return partes.Where(t => t.Nome == Nome).FirstOrDefault();
    }
    private void PopularSessao()
    {
        if (string.IsNullOrEmpty(_session.HttpContext.Session.GetString("Partes")))
        {
            _session.HttpContext.Session.SetString("Personagens", LerArquivo(personagensFile));
            _session.HttpContext.Session.SetString("Partes", LerArquivo(temporadasFile));
        }
    }
    private string LerArquivo(string fileName)
    {
        using (StreamReader leitor = new StreamReader(fileName))
        {
            string dados = leitor.ReadToEnd();
            return dados;
        }
    }
}
