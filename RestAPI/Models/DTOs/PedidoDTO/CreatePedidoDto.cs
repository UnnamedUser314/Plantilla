using System.ComponentModel.DataAnnotations;

namespace RestAPI.Models.DTOs.PedidoDTO
{
    public class CreatePedidoDto
    {
        [Required(ErrorMessage = "Usuario is required")]
        public int Usuario { get; set; }

        [Required(ErrorMessage = "Fecha is required")]
        public DateTime Fecha { get; set; }
        
        public List<int> Productos { get; set; }
    }
}
