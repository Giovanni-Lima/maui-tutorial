using GatelockVanLite.ViewModels;

namespace GatelockVanLite.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage(LoginViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
