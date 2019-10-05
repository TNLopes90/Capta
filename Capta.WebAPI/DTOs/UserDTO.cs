using System.ComponentModel.DataAnnotations;

namespace Capta.WebAPI.DTOs
{
    public class UserDTO
    {
        [Required(ErrorMessage="Username do usuário é de preenchimento obrigatório")]        
        public string UserName { get; set; }
        [Required(ErrorMessage="Email do usuário é de preenchimento obrigatório")]
        [EmailAddress(ErrorMessage="Digite um email válido")]
        public string Email { get; set; }
        [Required(ErrorMessage="Senha do usuário é de preenchimento obrigatório")]
        [MinLength(3, ErrorMessage="Sua senha deve conter no mínimo 3 caracteres")]
        public string Password { get; set; }
        [Required(ErrorMessage="Nome completo do usuário é de preenchimento obrigatório")]
        public string FullName { get; set; }
    }
}