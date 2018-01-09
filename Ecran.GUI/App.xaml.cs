﻿using System.Windows;

namespace Ecran.GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var viewModel = new MainViewModel(new ModelsMediator
            {
                Binary = new Binary(string.Empty),
                Resolution = new Resolution(800, 600)
            });

            var window = new MainWindow
            {
                DataContext = viewModel
            };

            window.ActionsUc.ViewModel = viewModel;

            window.Show();
        }
    }
}
