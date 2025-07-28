using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratacaoService.Application.DTOs
{
    public class ContratacaoResponse
    {
        public Guid Id { get; set; }
        public Guid PropostaId { get; set; }
        public string Cliente { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataContratacao { get; set; }
    }
}
