using Api.Models;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using static Api.AppConstant;

namespace Api.Services;

public interface IOAuthService
{
    public string GenerateOAuthRequestUrl(string redirectUrl, string codeChellange);
    public Task<OAuthToken> ExchangeCodeOnTokenAsync(string code, string codeVerifier, string redirectUrl);
    public Task<OAuthUserInfo> GetUserAsync(string token);
}

public class OAuthService : IOAuthService
{
    private readonly IHttpClientService httpClientService;

    public OAuthService(IHttpClientService httpClientService)
    {
        this.httpClientService = httpClientService;
    }

    public string GenerateOAuthRequestUrl(string redirectUrl, string codeChellange)
    {
        var scope = getAllScopes();
        var queryParams = new Dictionary<string, string>
            {
                { "client_id", General.ClientId},
                { "redirect_uri", redirectUrl },
                { "response_type", "code" },
                { "scope", scope },
                { "code_challenge", codeChellange },
                { "code_challenge_method", "S256" },
                { "access_type", "offline" }
            };

        var url = QueryHelpers.AddQueryString(Url.OAuthServerEndpoint, queryParams);
        return url;
    }

    public async Task<OAuthToken> ExchangeCodeOnTokenAsync(string code, string codeVerifier, string redirectUrl)
    {
        var authParams = new Dictionary<string, string>
            {
                { "client_id", General.ClientId },
                { "client_secret", General.ClientSecret },
                { "code", code },
                { "code_verifier", codeVerifier },
                { "grant_type", "authorization_code" },
                { "redirect_uri", redirectUrl }
            };

        var tokenResult = await httpClientService.PostAsync<OAuthToken>(Url.TokenServerEndpoint, authParams);
        return tokenResult;
    }

    private string getAllScopes()
    {
        var scopes = new List<string>()
            {
                Scopes.ReadPhoneNumbers,
                Scopes.ViewPrimaryUserEmail,
                Scopes.ViewCustomerRelatedInformation
            };
        return string.Join(" ", scopes);
    }

    public async Task<OAuthUserInfo> GetUserAsync(string token)
    {
        var userInfo = await httpClientService.GetAsync<OAuthUserInfo>(
            "https://www.googleapis.com/oauth2/v1/userinfo", 
             new Dictionary<string, string>()
             {
                 { "access_token", token }
             });

        return userInfo;
    }
}