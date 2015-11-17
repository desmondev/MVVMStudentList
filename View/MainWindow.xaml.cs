﻿using System.Windows;

namespace MVVMStudentList.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModel.MainWindowViewModel();
        }
    }
}