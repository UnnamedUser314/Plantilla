using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoginRegister.Interface;
using LoginRegister.Models;
using LoginRegister.View;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace LoginRegister.ViewModel;

public partial class DashboardViewModel : ViewModelBase
{
    private readonly IProductoServiceToApi _dicatadorServiceToApi;
    private readonly AddDicatadorViewModel _addViewModel;
    private readonly InformacionViewModel _infoViewModel;

    public DashboardViewModel(IProductoServiceToApi dicatadorServiceToApi, AddDicatadorViewModel addViewModel, InformacionViewModel infoViewModel)
    {
        _dicatadorServiceToApi = dicatadorServiceToApi;
        _addViewModel = addViewModel;
        _infoViewModel = infoViewModel;
        Productos = new List<ProductoDTO>(); 
        PagedDicatadores = new ObservableCollection<ProductoDTO>();

        ItemsPerPage = 5; 
        CurrentPage = 0; 
    }

    private List<ProductoDTO> Productos;

    private ProductoDTO _selectedProducto;

    [ObservableProperty]
    private ObservableCollection<ProductoDTO> pagedDicatadores;

    [ObservableProperty]
    private int currentPage; 

    [ObservableProperty]
    private int itemsPerPage; 

    public int TotalPages => (int)Math.Ceiling((double)Productos.Count / ItemsPerPage);

 
    public override async Task LoadAsync()
    {
        try
        {
            
            Productos.Clear();
            PagedDicatadores.Clear();

          
            IEnumerable<ProductoDTO> listaDicatadores = await _dicatadorServiceToApi.GetProductos();
            Productos.AddRange(listaDicatadores.OrderBy(d => d.Id));

          
            CurrentPage = 0;
            UpdatePagedDicatadores();
        }
        catch (Exception ex)
        {
            
            Console.WriteLine($"Error al cargar datos: {ex.Message}");
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
        var addDicatadorWindow = new AddDicatadorView();

        var addDicatadorViewModel = App.Current.Services.GetService<AddDicatadorViewModel>();
        addDicatadorWindow.DataContext = addDicatadorViewModel;
        addDicatadorWindow.ShowDialog();       
        await LoadAsync();
    }

    [RelayCommand]
    public async Task DeleteProducto()
    {
        try
        {
            if (SelectedProducto is null)
            {
                return;
            }
            await _dicatadorServiceToApi.DeleteProducto(SelectedProducto.Id);            
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }

        LoadAsync();
    }

    [RelayCommand]
    public async Task Logout() 
    {
        App.Current.Services.GetService<LoginDTO>().Token = "";
        App.Current.Services.GetService<MainViewModel>().SelectedViewModel = App.Current.Services.GetService<MainViewModel>().LoginViewModel;
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
    public async void  MyDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        if (e.Row.Item is ProductoDTO dicatadorDTO)
        {
           await _dicatadorServiceToApi.PutProducto(dicatadorDTO);
        }
    }

    public ProductoDTO SelectedProducto
    {
        get { return _selectedProducto; }
        set
        {
            _selectedProducto = value;
            OnPropertyChanged(nameof(SelectedProducto));
        }
    }
    private bool CanGoToPreviousPage() => CurrentPage > 0;

    private bool CanGoToNextPage() => CurrentPage < TotalPages - 1;
 
}

