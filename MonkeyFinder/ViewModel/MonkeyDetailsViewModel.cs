namespace MonkeyFinder.ViewModel;

[QueryProperty(nameof(Model.Monkey), nameof(Monkey))]
public partial class MonkeyDetailsViewModel : BaseViewModel
{
    [ObservableProperty]
    public partial Monkey Monkey { get; set; }

    private readonly IMap _map;

    public MonkeyDetailsViewModel(IMap map)
    {
        _map = map;
    }

    [RelayCommand]
    async Task ShowMonkeyOnMapAsync()
    {
        if (Monkey == null) return;
        try
        {
            await _map.OpenAsync(Monkey.Latitude, Monkey.Longitude, new MapLaunchOptions
            {
                Name = Monkey.Name,
                NavigationMode = NavigationMode.None
            });
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlertAsync(ex.Message, "Unable to open map.", "OK");
        }
    }

    [RelayCommand]
    async Task GoBackAsync()
    {
        await Shell.Current.GoToAsync("..");
    }
}
