using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoginRegister.Helpers;
using LoginRegister.Interface;
using LoginRegister.Models;
using LoginRegister.View;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegister.ViewModel
{
    public partial class InformacionViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ObservableCollection<PedidoDTO> items;

        private readonly IPedidoServiceToApi _pedidoServiceToApi;
        private readonly DetallesViewModel _detallesViewModel;
        private readonly IStringUtils _stringUtils;
        private int _pedidoId;

        [ObservableProperty]
        private ViewModelBase? _selectedViewModel;

        public InformacionViewModel(IPedidoServiceToApi pedidoServiceToApi, DetallesViewModel detallesViewModel, IStringUtils stringUtils)
        {
            _pedidoServiceToApi = pedidoServiceToApi;
            _detallesViewModel = detallesViewModel;
            _stringUtils = stringUtils;
            items = new ObservableCollection<PedidoDTO>();
        }

        public void SetIdPedido(int id)
        {
            _pedidoId = id;
        }

        public override async Task LoadAsync()
        {
            Items.Clear();
            IEnumerable<PedidoDTO> pedidos = await _pedidoServiceToApi.GetPedidos();
            if(pedidos is not null)
            {
                foreach (var pedido in pedidos)
                {
                    items.Add(pedido);
                }
            }
            
        }

        [RelayCommand]
        private async Task SelectViewModel(object? parameter)
        {
            SetIdPedido(_stringUtils.ConvertToInteger(parameter?.ToString() ?? string.Empty) ?? int.MinValue);
            _detallesViewModel.SetIdDicatador(_stringUtils.ConvertToInteger(parameter?.ToString() ?? string.Empty) ?? int.MinValue);
            _detallesViewModel.SetParentViewModel(this);
            SelectedViewModel = _detallesViewModel;
            await _detallesViewModel.LoadAsync();
        }

        [RelayCommand]
        public async Task AddPedido()
        {
            var addDicatadorWindow = new AddPedidoView();

            var addDicatadorViewModel = App.Current.Services.GetService<AddPedidoViewModel>();
            addDicatadorWindow.DataContext = addDicatadorViewModel;
            addDicatadorWindow.ShowDialog();
            await LoadAsync();
        }

        [RelayCommand]
        public async Task DeletePedido()
        {
            await _pedidoServiceToApi.DeletePedido(this._pedidoId);
            await LoadAsync();
        }
    }
}
