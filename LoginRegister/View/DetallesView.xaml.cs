using LoginRegister.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LoginRegister.View
{
    /// <summary>
    /// Lógica de interacción para DetallesView.xaml
    /// </summary>
    public partial class DetallesView : UserControl
    {
        public DetallesView()
        {
            InitializeComponent();
        }
        private void MyDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            App.Current.Services.GetService<DetallesViewModel>().MyDataGrid_CellEditEnding(sender, e);
        }
    }
}
