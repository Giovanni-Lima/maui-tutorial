using MonkeyFinder.Services.Interfaces;
using MonkeyFinder.Utils;

namespace MonkeyFinder.Services
{
    public class TokenService : ITokenService
    {
        public async Task<string> GetAccessTokenAsync() =>
            await SecureStorage.GetAsync(Constants.SecureStorage.AccessToken);

        public async Task SaveAccessTokenAsync(string accessToken) => 
            await SecureStorage.SetAsync(Constants.SecureStorage.AccessToken, accessToken);

        public void DeleteAccessToken() =>
            SecureStorage.Remove(Constants.SecureStorage.AccessToken);

    }
}
