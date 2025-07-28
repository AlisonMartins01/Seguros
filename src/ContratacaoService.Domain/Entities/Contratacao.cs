using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratacaoService.Domain.Entities
{
    public class Contratacao
    {
        public Guid Id { get; private set; }
        public Guid PropostaId { get; private set; }
        public string Cliente { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataContratacao { get; private set; }

        // Construtor protegido para o EF
        protected Contratacao() { }

        public Contratacao(Guid propostaId, string cliente, decimal valor)
        {
            Id = Guid.NewGuid();
            PropostaId = propostaId;
            Cliente = cliente;
            Valor = valor;
            DataContratacao = DateTime.UtcNow;
        }
    }
}
