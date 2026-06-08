namespace api.Domain.Image;

public class ImageFileResult
{
    public Stream FileStream { get; set; }
    public string ContentType { get; set; } = "";
    public string FileName { get; set; } = "";
}