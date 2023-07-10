using System;
using System.Windows;
using System.Windows.Controls;
using RocketCalculator.Models;
using RocketCalculator.ViewModels;

namespace RocketCalculator.Views
{
    public partial class Calculator : UserControl
    {
        public Calculator()
        {
            InitializeComponent();

            DataContext = new CalculationsViewModel();
        }
    }
}