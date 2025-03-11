using LoginRegister.Helpers;
using LoginRegister.Interface;
using LoginRegister.Models;



namespace LoginRegister.Service
{

    public class ProductoServiceToApi : IProductoServiceToApi
    {
        private readonly IHttpJsonProvider<ProductoDTO> _httpJsonProvider;


        public ProductoServiceToApi(IHttpJsonProvider<ProductoDTO> httpJsonProvider)
        {
            _httpJsonProvider = httpJsonProvider;
        }



        public async Task<IEnumerable<ProductoDTO>> GetProductos()
        {

            IEnumerable<ProductoDTO> productos = await _httpJsonProvider.GetAsync(Constants.PRODUCTO_URL);

            return productos;
        }

        public async Task<IEnumerable<ProductoDTO>> GetProductosByName(string name)
        {

            IEnumerable<ProductoDTO> productos= await _httpJsonProvider.GetByNameAsync(Constants.PRODUCTO_NAME_URL, name);

            return productos;
        }

        public async Task PostProducto(ProductoDTO producto)
        {
            try
            {
                if (producto == null) return;
                var response = await _httpJsonProvider.PostAsync(Constants.PRODUCTO_URL, producto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task PutProducto(ProductoDTO producto)
        {
            try
            {
                if (producto == null) return;
                var response = await _httpJsonProvider.PutAsync(Constants.PRODUCTO_URL + "/" + producto.Id, producto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task DeleteProducto(int productoIndex)
        {
            try
            {            
                var response = await _httpJsonProvider.Delete(Constants.PRODUCTO_URL + "/", productoIndex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }

}