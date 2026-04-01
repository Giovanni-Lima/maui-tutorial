global using CommunityToolkit.Mvvm.ComponentModel;
global using CommunityToolkit.Mvvm.Input;

namespace GatelockVanLite.ViewModels
{
    public partial class BaseViewModel(string title) : ObservableValidator
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        public partial bool IsBusy { get; set; }

        [ObservableProperty]
        public partial string Title { get; set; } = title;

        public bool IsNotBusy => !IsBusy;
    }
}
