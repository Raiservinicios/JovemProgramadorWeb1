namespace JovemProgramadorWeb1.Models
{
    public class Evento
    {
        public int codigo { get; set; }
        public string nomeEvento { get; set; }
        public DateTime dataEvento { get; set; }
        public string descricaoEvento { get; set; }
        public int capacidadeMaxima { get; set; }
        public bool participante { get; set; }
    }
}
