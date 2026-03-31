namespace MonkeyFinder;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        Resources.Add("AppVersion", $"Version {AppInfo.VersionString} ({AppInfo.BuildString})");
    }

	protected override Window CreateWindow(IActivationState activationState)
	{
		return new Window(new AppShell());
	}
}
