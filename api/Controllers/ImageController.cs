using System.Net;
using api.Domain.Image;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImageController(IImageDomainGet domainGet): ControllerBase
{
    [HttpGet("[action]")]
    public async Task<IActionResult> GetImage([FromQuery] string src)
    {
        if (string.IsNullOrWhiteSpace(src))
        {
            return BadRequest("Image source cannot be empty.");
        }

        // 1. Decode the source in case a full URL was passed and encoded
        var decodedSrc = WebUtility.UrlDecode(src);

        // 2. Fetch the result from your Domain Service
        var result = await domainGet.GetImage(decodedSrc);

        // 3. If nothing was found or an error occurred, return 404
        if (result == null)
        {
            return NotFound("The requested image could not be found.");
        }

        // 4. Return the file stream.
        // ASP.NET Core automatically closes and disposes of the stream
        // once it finishes transferring the bytes to the browser.
        return File(result.FileStream, result.ContentType);
    }
}