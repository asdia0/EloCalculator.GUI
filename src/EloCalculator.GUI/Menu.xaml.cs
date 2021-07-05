﻿namespace EloCalculator.GUI
{
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

    /// <summary>
    /// Interaction logic for Menu.xaml.
    /// </summary>
    public partial class Menu : UserControl
    {
        public Menu()
        {
            this.InitializeComponent();
        }

        public void LoadGame_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new();
            fileDialog.RestoreDirectory = true;
            fileDialog.Filter = "JSON files (*.json)|*.json";

            if (fileDialog.ShowDialog() == true)
            {
                GameDatabase.Load(fileDialog.FileName);
            }
        }

        public void LoadPlayer_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new();
            fileDialog.RestoreDirectory = true;
            fileDialog.Filter = "JSON files (*.json)|*.json";

            if (fileDialog.ShowDialog() == true)
            {
                PlayerDatabase.Load(fileDialog.FileName);
            }
        }
    }
}
