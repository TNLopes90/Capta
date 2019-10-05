using System.ComponentModel.DataAnnotations;

namespace Capta.WebAPI.DTOs
{
    public class HabilidadeDTO
    {
        public int HabilidadeId { get; set; }
        [Required(ErrorMessage="Nome da habilidade é de preenchimento obrigatório")]
        public string Nome { get; set; }
    }
}