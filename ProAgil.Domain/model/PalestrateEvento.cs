using ProAgil.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProAgil.Domain.Model
{
    public class PalestrateEvento
    {
        public int PalestranteId { get; set; }
        public Palestrante Paletrante { get; set; }
        public int EventoId { get; set; }

        public Evento Evento { get; set; }
    }
}
