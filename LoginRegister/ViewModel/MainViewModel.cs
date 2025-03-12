using CommunityToolkit.Mvvm.Input;
using System.Windows;


namespace LoginRegister.ViewModel;

public partial class MainViewModel : ViewModelBase
{
    private ViewModelBase? _selectedViewModel;
    private bool _isMenuEnabled;
    private bool _isMenuVisible;
    
    public MainViewModel(DashboardViewModel dashboardViewModel, LoginViewModel loginViewModel, RegistroViewModel registroViewModel, AddDicatadorViewModel addViewModel, InformacionViewModel informacionViewModel, DetallesViewModel detallesViewModel)
    {
        DashboardViewModel = dashboardViewModel;
        LoginViewModel = loginViewModel;
        RegistroViewModel = registroViewModel;
        AddDicatadorViewModel = addViewModel;
        InformacionViewModel = informacionViewModel;
        DetallesViewModel = detallesViewModel;
        _selectedViewModel = loginViewModel;

    }
    public bool IsMenuVisible
    {
        get { return _isMenuVisible; }
        set
        {
            _isMenuVisible = value;
            OnPropertyChanged(nameof(IsMenuVisible));
        }
    }
    public bool IsMenuEnabled
    {
        get => _isMenuEnabled;
        set => SetProperty(ref _isMenuEnabled, value);
    }
    public ViewModelBase? SelectedViewModel
    {
        get => _selectedViewModel;
        set
        {
            SetProperty(ref _selectedViewModel, value);
            if (value is LoginViewModel || value is RegistroViewModel)
            {
                IsMenuEnabled = false;
                IsMenuVisible = false;
            }
            else
            {
                IsMenuEnabled = true;
                IsMenuVisible = true;
            }
        }
    }

    public DashboardViewModel DashboardViewModel { get; }
    public LoginViewModel LoginViewModel { get; }
    public RegistroViewModel RegistroViewModel { get; }
    public AddDicatadorViewModel AddDicatadorViewModel { get; }
    public InformacionViewModel InformacionViewModel { get; }
    public DetallesViewModel DetallesViewModel { get; }


    public override async Task LoadAsync()
    {
        if (SelectedViewModel is not null)
        {
            await SelectedViewModel.LoadAsync();
        }
    }

    [RelayCommand]
    private async Task SelectViewModelAsync(object? parameter)
    {
        if (parameter is ViewModelBase viewModel)
        {
            SelectedViewModel = viewModel;
            await LoadAsync();
        }
    }

    

}




