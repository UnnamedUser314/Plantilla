using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoginRegister.Interface;
using LoginRegister.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Drawing;
using System.Windows;

namespace LoginRegister.ViewModel
{
    public partial class AddDicatadorViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string _nombre;

        [ObservableProperty]
        private string _precio;

        private readonly IProductoServiceToApi _productoServiceToApi;


        public AddDicatadorViewModel(IProductoServiceToApi productoServiceToApi, LoginDTO loginDTO)
        {
            _productoServiceToApi = productoServiceToApi;
        }

        [RelayCommand]
        public async Task Add()
        {
            if (string.IsNullOrEmpty(Nombre) ||
                string.IsNullOrEmpty(Precio))
            {
                MessageBox.Show("Por favor, rellene todos los campos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }



            ProductoDTO dicatadorDTO = new()
            {

                Nombre = Nombre,
                Precio = Double.Parse(Precio),
            };

            try
            {
                await _productoServiceToApi.PostProducto(dicatadorDTO);
                App.Current.Services.GetService<MainViewModel>().LoadAsync();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}


