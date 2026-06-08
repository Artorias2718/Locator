using Microsoft.AspNetCore.StaticFiles;
using System.Net.Http;

namespace api.Domain.Image;


public class ImageDomainGet(IWebHostEnvironment env, IHttpClientFactory httpClientFactory): IImageDomainGet
{
    private readonly string _localStoragePath = Path.Combine(env.ContentRootPath, "Uploads");

    public async Task<ImageFileResult?> GetImage(string src)
    {
        // 1. Check if the source is a remote URL
        if (Uri.TryCreate(src, UriKind.Absolute, out var uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
        {
            return await GetRemoteImage(src);
        }

        // 2. Otherwise, treat it as a local file name
        return await GetLocalImage(src);
    }

    private Task<ImageFileResult?> GetLocalImage(string fileName)
    {
        var path = Path.Combine(_localStoragePath, fileName);

        if (!File.Exists(path)) return null;

        var contentType = GetContentType(path);
        var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, useAsync: true);

        var result = new ImageFileResult { FileStream = stream, ContentType = contentType };
        return Task.FromResult<ImageFileResult?>(result);
    }

    private async Task<ImageFileResult?> GetRemoteImage(string url)
    {
        try
        {
            var client = httpClientFactory.CreateClient();

            // Use HttpCompletionOption.ResponseHeadersRead to stream the content directly
            // instead of downloading the whole image into server memory first.
            var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);

            if (!response.IsSuccessStatusCode) return null;

            var stream = await response.Content.ReadAsStreamAsync();
            var contentType = response.Content.Headers.ContentType?.MediaType ?? "application/octet-stream";

            return new ImageFileResult { FileStream = stream, ContentType = contentType };
        }
        catch (HttpRequestException)
        {
            // Log error (remote server down, 404, etc.)
            return null;
        }
    }

    private string GetContentType(string path)
    {
        var provider = new FileExtensionContentTypeProvider();
        return provider.TryGetContentType(path, out string contentType) ? contentType : "application/octet-stream";
    }
}