namespace MonkeyFinder.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> GetAccessTokenAsync();
        Task SaveAccessTokenAsync(string accessToken);
        void DeleteAccessToken();
    }
}
