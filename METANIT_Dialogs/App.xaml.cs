using METANIT_Dialogs.Models;
using METANIT_Dialogs.Services;
using METANIT_Dialogs.ViewModels;
using System.Windows;

namespace METANIT_Dialogs
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() 
        {
            Repository repository = new(new DefaultDialogService(), new FileService());
            ViewModel viewModel = new(new  Model(repository));
            MainWindow _mainWindow = new() { DataContext = viewModel };
            _mainWindow.Show();
        }
    }
}
