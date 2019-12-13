﻿using ProAgil.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProAgil.Domain.Model
{
   public  class Palestrante
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string MiniCurriculo { get; set; }

        public string ImagemUrl { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public List<RedeSocial> Redesociais { get; set; }

        public List<PalestrateEvento> PalestrateEventos { get; set; }
    }
}
