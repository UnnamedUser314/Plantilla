using System.ComponentModel.DataAnnotations;

namespace RestAPI.Models.DTOs.UsuarioDTO
{
    public class CreateUsuarioDto
    {
        [Required(ErrorMessage = "Nombre is required")]
        [MaxLength(20, ErrorMessage = "Max char is 15")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [MaxLength(50, ErrorMessage = "Max char is 50")]
        public string Email { get; set; }

    }
}
