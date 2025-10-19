namespace TakeNote.Models
{
    public class Nota
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Conteudo { get; set; } = string.Empty;
    }
}
