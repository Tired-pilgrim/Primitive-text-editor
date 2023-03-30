﻿using METANIT_Dialogs.Services;
using METANIT_Dialogs.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
            ViewModel viewModel = new(new DefaultDialogService(), new FileService());
            MainWindow _mainWindow = new() { DataContext = viewModel };
            _mainWindow.Show();
        }
    }
}