using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropostaServices.Domain.Enums;

namespace PropostaServices.Domain.Entities
{
    public class Proposta
    {
        public Guid Id { get; private set; }
        public string Cliente { get; private set; }
        public decimal Valor { get; private set; }
        public StatusProposta Status { get; private set; }
        public DateTime? DataCriacao { get; private set; }

        public Proposta(string cliente, decimal valor)
        {
            Id = Guid.NewGuid();
            Cliente = cliente;
            Valor = valor;
            Status = StatusProposta.EmAnalise;
            DataCriacao = DateTime.UtcNow;
        }

        public void Aprovar() => Status = StatusProposta.Aprovada;
        public void Rejeitar() => Status = StatusProposta.Rejeitada;
        public void MarcarEmAnalise() => Status = StatusProposta.EmAnalise;
    }
}
