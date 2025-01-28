using System;
using System.Security.Claims;
using System.Text.Json;

namespace HosxpUi.Layout.Providers;

public class Utility
{
    public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

             // Check for the "LoginName" claim
            if (keyValuePairs.ContainsKey("LoginName"))
            {
                var loginName = keyValuePairs["LoginName"].ToString();
                // Create a claim for LoginName if needed
                yield return new Claim("LoginName", loginName);
            }

            // Check for the "Role" claim and handle it separately
            if (keyValuePairs.ContainsKey("Role"))
            {
                var roles = keyValuePairs["Role"].ToString();
                // Handle multiple roles if they're comma-separated or a list
                var roleClaims = roles.Split(',')
                                    .Select(role => new Claim(ClaimTypes.Role, role.Trim()));
                // Return role claims along with other claims (excluding "Role" here)
                foreach (var roleClaim in roleClaims)
                {
                    yield return roleClaim;
                }
            }

            // Return all other claims
            foreach (var kvp in keyValuePairs.Where(kvp => kvp.Key != "LoginName" && kvp.Key != "Role"))
            {
                yield return new Claim(kvp.Key, kvp.Value.ToString());
            }
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
}
