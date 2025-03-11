using System.ComponentModel.DataAnnotations;

namespace RestAPI.Models.DTOs.UserDto
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Field required: Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Field required: Password")]      
        public string Password { get; set; }


    }
}
