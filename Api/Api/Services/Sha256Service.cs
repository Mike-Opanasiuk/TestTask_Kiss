using IdentityModel;
using System.Security.Cryptography;
using System.Text;

namespace Api.Services;

public interface ISha256Service
{
    abstract string ComputeHash(string codeVerifier);
}

public class Sha256Service : ISha256Service
{
    public string ComputeHash(string codeVerifier)
    {
        using var sha256 = SHA256.Create();
        var challengeBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(codeVerifier));
        var codeChallenge = Base64Url.Encode(challengeBytes);
        return codeChallenge;
    }
}
