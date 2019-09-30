namespace Capta.WebAPI.DTOs
{
    public class JogadorDTO
    {
        public int JogadorId { get; set; }
        public string Nome { get; set; }
        public decimal Peso { get; set; }
        public decimal Altura { get; set; }
        public TimeDTO Time { get; }
    }
}