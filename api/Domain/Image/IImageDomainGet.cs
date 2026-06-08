namespace api.Domain.Image;

public interface IImageDomainGet
{
    public Task<ImageFileResult?> GetImage(string src);
}