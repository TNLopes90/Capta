using System.Collections.Generic;

namespace Capta.Domain
{
    public class Jogador
    {
        public int JogadorId { get; set; }
        public string Nome { get; set; }
        public decimal Peso { get; set; }
        public decimal Altura { get; set; }
        public IEnumerable<JogadorHabilidade> JogadorHabilidades { get; set; }
        public int? TimeId { get; set; }
        public Time Time { get; }
    }
}