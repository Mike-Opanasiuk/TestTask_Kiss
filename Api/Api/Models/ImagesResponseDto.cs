namespace Api.Models;

public class ImagesResponseDto
{
    public IEnumerable<ImageDto> Images { get; set; } = new List<ImageDto>();
    public int TotalCount { get; set; }
}
