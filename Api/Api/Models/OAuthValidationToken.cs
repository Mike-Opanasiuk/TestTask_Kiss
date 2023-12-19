using Newtonsoft.Json;

namespace Api.Models;

public class OAuthValidationToken
{
    [JsonProperty("expires_in")]
    public string ExpiresIn { get; set; }

}
