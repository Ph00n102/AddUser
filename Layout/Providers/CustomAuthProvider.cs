using System.Security.Claims;
using System.Text.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using System.IdentityModel.Tokens.Jwt;
using MudBlazor;

namespace HosxpUi.Layout.Providers
{
    public class CustomAuthProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly NavigationManager _navigationManager;
         public event Action OnAuthenticationStateChanged;
        public CustomAuthProvider(ILocalStorageService localStorageService, NavigationManager navigationManager)
        {
            _localStorageService = localStorageService;
            _navigationManager = navigationManager;
        }

        // public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        // {
        //     var jwtToken = await _localStorageService.GetItemAsync<string>("jwt-access-token");
        //     if (string.IsNullOrEmpty(jwtToken) || IsTokenExpired(jwtToken))
        //     {
        //         // Token is either missing or expired, navigate to the login page
        //         _navigationManager.NavigateTo("/login", false);  // true forces a reload of the page
        //         return new AuthenticationState(
        //             new ClaimsPrincipal(new ClaimsIdentity()));
        //     }

        //     return new AuthenticationState(new ClaimsPrincipal(
        //         new ClaimsIdentity(ParseClaimsFromJwt(jwtToken), "JwtAuth")));
        // }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var currentUri = new Uri(_navigationManager.Uri).AbsolutePath; // Get the current URL path
            var jwtToken = await _localStorageService.GetItemAsync<string>("jwt-access-token");

            if (currentUri.Equals("/login", StringComparison.OrdinalIgnoreCase))
            {
                // Check if there's a valid JWT token after login
                if (!string.IsNullOrEmpty(jwtToken) && !IsTokenExpired(jwtToken))
                {
                    return new AuthenticationState(new ClaimsPrincipal(
                        //new ClaimsIdentity(ParseClaimsFromJwt(jwtToken), "JwtAuth")));
                        new ClaimsIdentity(Utility.ParseClaimsFromJwt(jwtToken), "JwtAuth")));
                }

                // If no valid token, return an empty authentication state
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            if (string.IsNullOrEmpty(jwtToken) || IsTokenExpired(jwtToken))
            {
                // Token is either missing or expired, navigate to the login page
                _navigationManager.NavigateTo("/loginwithoutotp", false); // true forces a reload of the page
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            return new AuthenticationState(new ClaimsPrincipal(
                //new ClaimsIdentity(ParseClaimsFromJwt(jwtToken), "JwtAuth")));
                new ClaimsIdentity(Utility.ParseClaimsFromJwt(jwtToken), "JwtAuth")));
        }

        private bool IsTokenExpired(string token)
        {
            var jwtToken = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
            var exp = jwtToken?.Payload?.Exp;

            if (exp == null)
                return true; // If there's no "exp" claim, treat it as expired

            var expirationDate = DateTimeOffset.FromUnixTimeSeconds(exp.Value);
            return expirationDate < DateTimeOffset.UtcNow;
        }

        // private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        // {
        //     var payload = jwt.Split('.')[1];
        //     var jsonBytes = ParseBase64WithoutPadding(payload);
        //     var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

        //      // Check for the "LoginName" claim
        //     if (keyValuePairs.ContainsKey("LoginName"))
        //     {
        //         var loginName = keyValuePairs["LoginName"].ToString();
        //         // Create a claim for LoginName if needed
        //         yield return new Claim("LoginName", loginName);
        //     }

        //     // Check for the "Role" claim and handle it separately
        //     if (keyValuePairs.ContainsKey("Role"))
        //     {
        //         var roles = keyValuePairs["Role"].ToString();
        //         // Handle multiple roles if they're comma-separated or a list
        //         var roleClaims = roles.Split(',')
        //                             .Select(role => new Claim(ClaimTypes.Role, role.Trim()));
        //         // Return role claims along with other claims (excluding "Role" here)
        //         foreach (var roleClaim in roleClaims)
        //         {
        //             yield return roleClaim;
        //         }
        //     }

        //     // Return all other claims
        //     foreach (var kvp in keyValuePairs.Where(kvp => kvp.Key != "LoginName" && kvp.Key != "Role"))
        //     {
        //         yield return new Claim(kvp.Key, kvp.Value.ToString());
        //     }
        // }

        // private static byte[] ParseBase64WithoutPadding(string base64)
        // {
        //     switch (base64.Length % 4)
        //     {
        //         case 2: base64 += "=="; break;
        //         case 3: base64 += "="; break;
        //     }
        //     return Convert.FromBase64String(base64);
        // }


        public void NotifyAuthState()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

    }
}