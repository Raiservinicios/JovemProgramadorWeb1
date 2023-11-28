namespace JovemProgramadorWeb1.Models
{
    public class Socio
    {
        public int codigo { get; set; }
        public string nomeCompleto { get; set; }
        public string cpf { get; set; }
        public DateTime dataNascimento { get; set; }
        public string endereco { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public DateTime dataAdesao { get; set; }
        public bool flagTitular { get; set; }

        public int codigoUsuario { get; set; }
    }
}

