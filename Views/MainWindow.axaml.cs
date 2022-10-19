using Avalonia.Controls;
using Kruchinin_28092022.ViewModels;

namespace Kruchinin_28092022.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel.Page1 = this;
        }
    }
}