using System.Collections.Generic;

namespace Capta.Domain
{
    public class Habilidade
    {
        public int HabilidadeId { get; set; }
        public string Nome { get; set; }
        public IEnumerable<JogadorHabilidade> JogadorHabilidades { get; set; }
    }
}