using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Api.Services;

public interface IHttpClientService
{
    Task<T> GetAsync<T>(string endpoint, Dictionary<string, string> queryParameters, string accessToken = "access_token");
    Task<T> PostAsync<T>(string endpoint, Dictionary<string, string> bodyParameters);
}


public class HttpClientService : IHttpClientService
{
    #region Public
    public async Task<T> GetAsync<T>(string endpoint, Dictionary<string, string> queryParameters, string accessToken = "access_token")
    {
        return await SendHttpRequestAsync<T>(HttpMethod.Get, endpoint, accessToken, queryParameters);
    }

    public async Task<T> PostAsync<T>(string endpoint, Dictionary<string, string> bodyParameters)
    {
        var httpContent = new FormUrlEncodedContent(bodyParameters);
        return await SendHttpRequestAsync<T>(HttpMethod.Post, endpoint, httpContent: httpContent);
    }
    #endregion

    #region Private
    private async Task<T> SendHttpRequestAsync<T>(HttpMethod httpMethod, string endpoint, string accessToken = null, Dictionary<string, string> queryParams = null, HttpContent httpContent = null)
    {
        var url = queryParams != null
            ? QueryHelpers.AddQueryString(endpoint, queryParams)
            : endpoint;

        var request = new HttpRequestMessage(httpMethod, url);

        if (accessToken != null)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        if (httpContent != null)
        {
            request.Content = httpContent;
        }

        using var httpClient = new HttpClient();
        using var response = await httpClient.SendAsync(request);

        var resultJson = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(resultJson);
        }

        var result = JsonConvert.DeserializeObject<T>(resultJson);
        return result!;
    }
    #endregion
}