namespace PropostaServices.Application.DTOs
{
    public class CriarPropostaRequest
    {
        public string Cliente { get; set; } = string.Empty;
        public decimal Valor { get; set; }
    }
}
