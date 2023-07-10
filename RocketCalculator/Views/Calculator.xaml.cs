using System.Windows.Controls;
using RocketCalculator.Services;
using RocketCalculator.ViewModels;

namespace RocketCalculator.Views
{
    public partial class Calculator : UserControl
    {
        public Calculator()
        {
            InitializeComponent();

            var calculationsViewModel = new CalculationsViewModel();
            calculationsViewModel.SubscribeEvents();
            
            DataContext = calculationsViewModel;
        }
    }
}