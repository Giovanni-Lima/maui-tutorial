namespace MonkeyFinder.ViewModel;

public partial class LoginViewModel : BaseViewModel
{
    [ObservableProperty]
    public partial string UserName { get; set; }

    [ObservableProperty]
    public partial string Password { get; set; }


    public LoginViewModel()
    {
        Title = "Login";
    }

    [RelayCommand]
    async Task LoginAsync()
    {
        await Shell.Current.DisplayAlertAsync(
                title: "Clicked",
                message: $"USER: {UserName} PASSWORD: {Password}",
                cancel: "OK");
    }
}
