using ProAgil.Domain.Model;
using System;
using System.Collections.Generic;

namespace ProAgil.Domain.Model
{
    public class Evento
    {
        public int Id { get; set; }

        public string Local { get; set; }

        public DateTime DataEvento { get; set; }

        public string Tema { get; set; }

        public int QtdPessoas { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string ImagemUrl { get; set; }

        public List<Lote> Lotes { get; set; }

        public List<RedeSocial> Redesociais { get; set; }

        public List<PalestrateEvento> PalestrateEventos { get; set; }

    }
}