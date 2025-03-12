using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoginRegister.Interface;
using LoginRegister.Models;
using LoginRegister.View;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoginRegister.ViewModel
{
    public partial class AddProductoToPedidoViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string _nombre;

        [ObservableProperty]
        private string _precio;

        private int _pedidoId;

        private readonly IProductoServiceToApi _productoServiceToApi;
        private readonly IPedidoServiceToApi _pedidoServiceToApi;
        


        public AddProductoToPedidoViewModel(IProductoServiceToApi productoServiceToApi, IPedidoServiceToApi pedidoServiceToApi, LoginDTO loginDTO)
        {
            _productoServiceToApi = productoServiceToApi;
            _pedidoServiceToApi = pedidoServiceToApi;
        }

        [RelayCommand]
        public async Task Add()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                MessageBox.Show("Por favor, rellene el campo Nombre", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            string productName = Nombre;
            

            try
            {
                PedidoDTO pedido = await _pedidoServiceToApi.GetPedidoById(_pedidoId);
                IEnumerable<ProductoDTO> productos = await _productoServiceToApi.GetProductosByName(productName) ?? new List<ProductoDTO>();

                if (!productos.Any()) {
                    MessageBox.Show("Por favor, introduzca un nombre de producto existente");
                    return;
                }

                foreach (ProductoDTO producto in productos)
                {
                    pedido.Productos.Add(producto.Id);
                }

                await _pedidoServiceToApi.PutPedido(pedido);
                App.Current.Windows.OfType<Window>().FirstOrDefault(w => w is AddProductoToPedidoView).Close();
                App.Current.Services.GetService<MainViewModel>().LoadAsync();
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        public void SetIdPedido(int id)
        {
            _pedidoId = id;
        }
    }
}
