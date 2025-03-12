using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoginRegister.Helpers;
using LoginRegister.Interface;
using LoginRegister.Models;
using LoginRegister.Service;
using LoginRegister.View;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Windows;
using System.Windows.Controls;



namespace LoginRegister.ViewModel
{
    public partial class DetallesViewModel : ViewModelBase
    {

        [ObservableProperty]
        private ObservableCollection<DicatadorDTO> _items;

        private int _dicatadorId;
        private InformacionViewModel _informacionViewModel;
        private readonly IHttpJsonProvider<DicatadorDTO> _httpJsonProvider;
        private readonly IFileService<DicatadorDTO> _fileService;
        private readonly AddProductoToPedidoViewModel _addProductoToPedidoViewModel;
        private IProductoServiceToApi _productoServiceToApi;
        private IPedidoServiceToApi _pedidoServiceToApi;
        
     
        public DetallesViewModel(IHttpJsonProvider<DicatadorDTO> httpJsonProvider,
            IFileService<DicatadorDTO> fileService, IProductoServiceToApi productoServiceToApi, IPedidoServiceToApi pedidoServiceToApi
            , AddProductoToPedidoViewModel addProductoToPedidoViewModel)
        {
            _httpJsonProvider = httpJsonProvider;
            _fileService = fileService;
            _items = new ObservableCollection<DicatadorDTO>();
            _productoServiceToApi = productoServiceToApi;
            _pedidoServiceToApi = pedidoServiceToApi;
            _addProductoToPedidoViewModel = addProductoToPedidoViewModel;

            Productos = new List<ProductoDTO>();
            PagedDicatadores = new ObservableCollection<ProductoDTO>();

            ItemsPerPage = 5;
            CurrentPage = 0;
        }

        private List<ProductoDTO> Productos;


        private ProductoDTO _selectedElement;

        [ObservableProperty]
        private ObservableCollection<ProductoDTO> pagedDicatadores;

        [ObservableProperty]
        private int currentPage;

        [ObservableProperty]
        private int itemsPerPage;

        public int TotalPages => (int)Math.Ceiling((double)Productos.Count / ItemsPerPage);
        [ObservableProperty]
        private DicatadorDTO _Dicatador;

        public void SetIdDicatador(int id)
        {
            _dicatadorId = id;
        }

        public override async Task LoadAsync()
        {
            try
            {

                Productos.Clear();
                PagedDicatadores.Clear();

                PedidoDTO pedido = await _pedidoServiceToApi.GetPedidoById(_dicatadorId);

                IEnumerable<ProductoDTO> listaDicatadores = await _productoServiceToApi.GetProductos();
                listaDicatadores = listaDicatadores.Where(x => pedido.Productos.Contains(x.Id)).ToList();
                
                Productos.AddRange(listaDicatadores.OrderBy(d => d.Nombre));
                CurrentPage = 0;
                UpdatePagedDicatadores();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error al cargar datos: {ex.Message}");
            }
        }

        internal void SetParentViewModel(ViewModelBase informacionViewModel)
        {
            if (informacionViewModel is InformacionViewModel informacionview)
            {
                _informacionViewModel = informacionview;
            }
        }

        [RelayCommand]
        private async Task Close(object? parameter)
        {
            if (_informacionViewModel != null)
            {
                _informacionViewModel.SelectedViewModel = null;
            }
        }

        [RelayCommand]
        public void Save()
        {
        
            var saveFileDialog = new SaveFileDialog
            {
                Filter = Constants.JSON_FILTER
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                _fileService.Save(saveFileDialog.FileName, (IEnumerable<DicatadorDTO>)Dicatador);
            }
        }

        private void UpdatePagedDicatadores()
        {

            PagedDicatadores.Clear();

            var pagedItems = Productos.Skip(CurrentPage * ItemsPerPage).Take(ItemsPerPage).ToList();
            foreach (var item in pagedItems)
            {
                PagedDicatadores.Add(item);
            }
        }

        [RelayCommand]
        public async Task AddProducto()
        {
            var addDicatadorWindow = new AddProductoToPedidoView();
            _addProductoToPedidoViewModel.SetIdPedido(_dicatadorId);
            var addDicatadorViewModel = App.Current.Services.GetService<AddProductoToPedidoViewModel>();
            addDicatadorWindow.DataContext = addDicatadorViewModel;
            addDicatadorWindow.ShowDialog();
            await LoadAsync();
        }

        [RelayCommand]
        public async Task DeleteProducto()
        {
            try
            {
                if (SelectedElement is null)
                {
                    return;
                }
                PedidoDTO pedido = await _pedidoServiceToApi.GetPedidoById(_dicatadorId);
                if (pedido is null) return;
                List<int> productsReplace = new List<int>();
                foreach (var item in pedido.Productos)
                {
                    
                    if(item != SelectedElement.Id)
                    {
                        productsReplace.Add(item);
                    }
                }
                pedido.Productos = productsReplace;
                await _pedidoServiceToApi.PutPedido(pedido);
                App.Current.Services.GetService<MainViewModel>().LoadAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            LoadAsync();
        }

        [RelayCommand]
        public void PreviousPage()
        {
            if (CurrentPage > 0)
            {
                CurrentPage--;
                UpdatePagedDicatadores();
            }
        }

        [RelayCommand]
        public void NextPage()
        {
            if (CurrentPage < TotalPages - 1)
            {
                CurrentPage++;
                UpdatePagedDicatadores();
            }
        }
        public async void MyDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.Row.Item is ProductoDTO dicatadorDTO)
            {
                await _productoServiceToApi.PutProducto(dicatadorDTO);
            }
        }

        public ProductoDTO SelectedElement
        {
            get { return _selectedElement; }
            set
            {
                _selectedElement = value;
                OnPropertyChanged(nameof(SelectedElement));
            }
        }
        private bool CanGoToPreviousPage() => CurrentPage > 0;

        private bool CanGoToNextPage() => CurrentPage < TotalPages - 1;

    }
}
