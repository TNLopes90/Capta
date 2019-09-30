using System.Collections.Generic;

namespace Capta.WebAPI.DTOs
{
    public class TimeDTO
    {
        public int TimeId { get; set; }
        public string Nome { get; set; }
        public int Forca { get; set; }
        public IEnumerable<JogadorDTO> Jogadores { get; set; }
    }
}