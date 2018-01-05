﻿using Echoic.Binary;
using Microsoft.Win32;
using System;
using System.Windows;

namespace Ecran.GUI.Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class View : Window
    {
        readonly ViewModel viewModel;

        readonly int divideValue = (int)Math.Pow(2, 8);
        readonly int offsetValue = 0xA68;

        public View(ViewModel mainView)
        {
            InitializeComponent();
            viewModel = mainView;
            DataContext = viewModel;
        }

        void Save(object sender, RoutedEventArgs e)
        {
            viewModel.Path = @"E:\roman\Documents\My Games\Halo CE\savegames\New001\blam.sav";

            new Blam(viewModel.Path).Patch(new Func<byte[]>(() =>
            {
                return new byte[]
                {
                    (byte) (viewModel.Width % divideValue),
                    (byte) (viewModel.Width / divideValue),

                    (byte) (viewModel.Height % divideValue),
                    (byte) (viewModel.Height / divideValue),
                };
            })(), offsetValue);
        }

        private void Browse(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                viewModel.Path = openFileDialog.FileName;
            }
        }
    }
}
