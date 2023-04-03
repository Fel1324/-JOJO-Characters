namespace JoJo_Characters.Models
{
    public class Personagem
    {
        //Atributos
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string PaisDeNascimento { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public string Raça { get; set; }
        public string Stand { get; set; }
        public List<string> Parte { get; set; }
        public string Imagem { get; set; } 
    
        //Método Construtor
        public Personagem()
        {
            Parte = new List<string>(); 
        }
    }
}
