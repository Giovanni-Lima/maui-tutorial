using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using AndroidX.Core.View;
using AColor = Android.Graphics.Color;

namespace MonkeyFinder;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        WindowCompat.SetDecorFitsSystemWindows(Window, false);

        Window.SetStatusBarColor(AColor.ParseColor("#fb9705"));

        var controller = WindowCompat.GetInsetsController(Window, Window.DecorView);

        if (controller != null)
        {
            controller.AppearanceLightStatusBars = true; // icone nere
        }
    }
}
