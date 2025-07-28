using PropostaServices.Domain.Enums;

namespace PropostaServices.Application.DTOs
{
    public class AlterarStatusPropostaRequest
    {
        public StatusProposta NovoStatus { get; set; }
    }
}
