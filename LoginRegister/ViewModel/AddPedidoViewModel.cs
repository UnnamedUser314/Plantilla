using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoginRegister.Interface;
using LoginRegister.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoginRegister.ViewModel
{
    public partial class AddPedidoViewModel : ViewModelBase
    {
        [ObservableProperty]
        private DateTime _selectedDate;

        [ObservableProperty]
        private string _selectedItem;

        [ObservableProperty]
        private ObservableCollection<string> items;

        private int _pedidoId;

        private readonly IProductoServiceToApi _productoServiceToApi;
        private readonly IPedidoServiceToApi _pedidoServiceToApi;
        private readonly IUsuarioServiceToApi _usuarioServiceToApi;



        public AddPedidoViewModel(IProductoServiceToApi productoServiceToApi, IPedidoServiceToApi pedidoServiceToApi, LoginDTO loginDTO, IUsuarioServiceToApi usuarioServiceToApi)
        {
            _productoServiceToApi = productoServiceToApi;
            _pedidoServiceToApi = pedidoServiceToApi;
            _usuarioServiceToApi = usuarioServiceToApi;
            items = new ObservableCollection<string>();

            LoadAsync();
        }

        public override async Task LoadAsync()
        {
            try
            {
                SelectedDate = DateTime.Now;
                Items.Clear();

                IEnumerable<UsuarioDTO> listaDicatadores = await _usuarioServiceToApi.GetUsuarios();

                foreach (UsuarioDTO element in listaDicatadores)
                {
                    Items.Add(element.Nombre);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error al cargar datos: {ex.Message}");
            }
        }

        [RelayCommand]
        public async Task Add()
        {
            if (string.IsNullOrEmpty(SelectedItem))
            {
                MessageBox.Show("Por favor, rellene el campo Nombre", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                IEnumerable<UsuarioDTO> usuarios = await _usuarioServiceToApi.GetUsuarioByName(SelectedItem);

                PedidoDTO pedido = new PedidoDTO()
                {
                    Usuario = usuarios.FirstOrDefault().Id,
                    Fecha = SelectedDate,
                    Productos = new List<int>()
                };

                await _pedidoServiceToApi.PostPedido(pedido);
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
