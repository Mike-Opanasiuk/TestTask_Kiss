using Firebase.Storage;
using System.Net;

namespace Api.Services;

public interface IImageService
{
    Task<string> LoadImageAsync(string url);
}

public class ImageService : IImageService
{
    public async Task<string> LoadImageAsync(string url)
    {
        var httpClient = new HttpClient();

        byte[] imageBytes = await httpClient.GetByteArrayAsync(url);

        using MemoryStream stream = new MemoryStream(imageBytes);

        return await new FirebaseStorage(AppConstant.Url.FireBase)
         .Child(Guid.NewGuid() + Path.GetExtension(url))
         .PutAsync(stream);
    }
}
