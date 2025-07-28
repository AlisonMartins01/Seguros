using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguros.Contracts.Events
{
    public class PropostaAprovadaEvent
    {
        public Guid PropostaId { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public decimal Valor { get; set; }
    }
}
