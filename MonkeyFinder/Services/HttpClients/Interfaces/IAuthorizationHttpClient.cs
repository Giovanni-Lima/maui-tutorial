namespace MonkeyFinder.Services.HttpClients.Interfaces
{
    public interface IAuthorizationHttpClient
    {
        Task<string> GetAuthorizationTokenAsync(string email, string cri);
    }
}
