namespace Capta.Domain
{
    public class JogadorHabilidade
    {
        public int JogadorId { get; set; }
        public Jogador Jogador { get; set; }
        public int HabilidadeId { get; set; }
        public Habilidade Habilidade { get; set; }
        public int Capacidade { get; set; }
    }
}