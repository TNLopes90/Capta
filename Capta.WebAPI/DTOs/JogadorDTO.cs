using System.ComponentModel.DataAnnotations;

namespace Capta.WebAPI.DTOs
{
    public class JogadorDTO
    {
        public int JogadorId { get; set; }
        [Required(ErrorMessage="Nome do jogador é de preenchimento obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage="Peso do jogador é de preenchimento obrigatório")]
        public decimal Peso { get; set; }
        [Required(ErrorMessage="Altura do jogador é de preenchimento obrigatório")]
        public decimal Altura { get; set; }
        public TimeDTO Time { get; }
    }
}