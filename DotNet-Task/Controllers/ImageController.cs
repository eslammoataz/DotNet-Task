using DotNet_Task.Helpers;
using DotNet_Task.Models;
using DotNet_Task.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_Task.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        public IImageService ImageService { get; }

        public ImageController(IImageService imageService)
        {
            ImageService = imageService;
        }

        [HttpGet]
        public ActionResult<List<Image>> GetAllImages()
        {
            var images = ImageService.GetAllImages();
            return Ok(images);
        }

        [HttpPost]
        public IActionResult AddImage(AddImagedto imagedto)
        {
            var newImage = ImageService.AddImage(imagedto);
            return Ok(newImage);
        }

    }
}
