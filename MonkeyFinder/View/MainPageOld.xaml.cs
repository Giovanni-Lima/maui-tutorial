namespace MonkeyFinder.View;

public partial class MainPageOld : ContentPage
{
	public MainPageOld(MonkeysViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}

