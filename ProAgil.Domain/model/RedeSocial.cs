using ProAgil.Domain.Model;

namespace ProAgil.Domain.Model
{
    public class RedeSocial
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string URL { get; set; }
        public int? EventoId { get; set; }

        public Evento Evento { get;  }
        public int? PatestranteId { get; set; }

        public Palestrante Palestrante { get; set; }
    }
}