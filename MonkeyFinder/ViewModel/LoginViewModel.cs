using CommunityToolkit.Mvvm.ComponentModel;
using MonkeyFinder.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MonkeyFinder.ViewModel;

public partial class LoginViewModel : BaseViewModel
{
    private readonly ITokenService _tokenService;

    public LoginViewModel(ITokenService tokenService)
    {
        Title = "LOGIN";
        _tokenService = tokenService;
    }

    [ObservableProperty]
    [Required(ErrorMessage = "Email obbligatoria")]
    [EmailAddress(ErrorMessage = "Email non valida")]
    [NotifyPropertyChangedFor(nameof(EmailError))]
    public partial string Email { get; set; }
    public string EmailError => GetErrors(nameof(Email)).FirstOrDefault()?.ErrorMessage;


    [ObservableProperty]
    [Required(ErrorMessage = "Password obbligatoria")]
    [MinLength(6, ErrorMessage = "Minimo 6 caratteri")]
    [NotifyPropertyChangedFor(nameof(PasswordError))]
    public partial string Password { get; set; }
    public string PasswordError => GetErrors(nameof(Password)).FirstOrDefault()?.ErrorMessage;

    [ObservableProperty]
    public partial bool NotFirstAttempt { get; set; }


    partial void OnEmailChanged(string value) => ValidateProperty(value, nameof(Email));
    
    partial void OnPasswordChanged(string value) => ValidateProperty(value, nameof(Password));
    
    public bool Validate()
    {
        ValidateAllProperties();
        OnPropertyChanged(nameof(EmailError));
        OnPropertyChanged(nameof(PasswordError));

        return !HasErrors;
    }

    [RelayCommand]
    async Task LoginAsync()
    {
        NotFirstAttempt = true;

        if (!Validate())
            return;

        await _tokenService.SaveAccessTokenAsync($"USER: {Email} PASSWORD: {Password}");
    }
}
