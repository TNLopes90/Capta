using System.Collections.Generic;

namespace Capta.Domain
{
    public class Time
    {
        public int TimeId { get; set; }
        public string Nome { get; set; }
        public int Forca { get; set; }
        public IEnumerable<Jogador> Jogadores { get; set; }
    }
}