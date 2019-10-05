using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Capta.WebAPI.DTOs
{
    public class TimeDTO
    {
        public int TimeId { get; set; }
        [Required(ErrorMessage="Nome do time é de preenchimento obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage="Força do time é de preenchimento obrigatório")]
        [Range(1, 100, ErrorMessage="A força do time deve ser entre 1 e 100")]
        public int Forca { get; set; }
        public IEnumerable<JogadorDTO> Jogadores { get; set; }
    }
}