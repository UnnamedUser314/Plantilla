using System.ComponentModel.DataAnnotations;

namespace RestAPI.Models.DTOs.ProductoDTO
{
    public class CreateProductoDto
    {
        [Required(ErrorMessage = "Nombre is required")]
        [MaxLength(50, ErrorMessage = "Max char is 50")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Precio is required")]        
        public double Precio { get; set; }
    }
}
