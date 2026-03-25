using MonkeyFinder.Services;

namespace MonkeyFinder.ViewModel;

public partial class MonkeysViewModel : BaseViewModel
{
    public ObservableCollection<Monkey> Monkeys { get; } = new();
    private readonly MonkeyService _monkeyService;
    private readonly IConnectivity _connectivity;
    private readonly IGeolocation _geolocation;
    public MonkeysViewModel(MonkeyService monkeyService, IConnectivity connectivity, IGeolocation geolocation)
    {
        Title = "Monkey Finder";
        _monkeyService = monkeyService;
        _connectivity = connectivity;
        _geolocation = geolocation;
    }

    [RelayCommand]
    async Task GetClosestMonkeyAsync()
    {
        if (IsBusy || Monkeys.Count == 0) return;

        try
        {
            var location =
                await _geolocation.GetLastKnownLocationAsync() ??
                await _geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(30)
                });

            if (location == null) return;

            var nearest = Monkeys
                .OrderBy(m => location.CalculateDistance(
                    m.Latitude, 
                    m.Longitude, 
                    DistanceUnits.Kilometers))
                .FirstOrDefault();

            if (nearest == null) return;

            await Shell.Current.DisplayAlertAsync(
                title: "Closest Monkey",
                message: $"{nearest.Name} in {nearest.Location}",
                cancel: "OK");

        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlertAsync(ex.Message, "Not possible to get closest monkey.", "OK");
            return;
        }
    }

    [RelayCommand]
    async Task GoToDetailsAsync(Monkey monkey)
    {
        if (monkey is null) return;

        await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object>
        {
            { nameof(Monkey), monkey }
        });
    }

    [RelayCommand]
    async Task GetMonkeysAsync()
    {
        if (IsBusy)
            return;

        try
        {
            if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlertAsync("No Internet!", "Please check your internet connection and try again.", "OK");
                return;
            }

            IsBusy = true;
            var monkeys = await _monkeyService.GetMonkeys();

            if (Monkeys.Count != 0)
                Monkeys.Clear();

            foreach (var monkey in monkeys)
                Monkeys.Add(monkey);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
            await Shell.Current.DisplayAlertAsync("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }

    }
}
