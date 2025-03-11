using LoginRegister.Models;


namespace LoginRegister.Interface
{
    public interface IProductoServiceToApi
    {
        // Obtiene un Dicatadores desde la API
        Task<IEnumerable<ProductoDTO>> GetProductos();
        Task<IEnumerable<ProductoDTO>> GetProductosByName(string name);

        // Agrega un Dicatador a la API
        Task PostProducto(ProductoDTO dicatador);

        // Modifica un Dicatador ya existente
        Task PutProducto(ProductoDTO dicatador);
        Task DeleteProducto(int productoIndex);
    }
}
