namespace JovemProgramadorWeb1.Models
{
    public class Fatura
    {
        public int codigo { get; set; }
        public string mesAnoFatura { get; set; }
        public decimal valor { get; set; }
        public bool flagPagamento { get; set; }
        public int codigoSocio { get; set; }
    }
}
