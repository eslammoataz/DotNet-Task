using DotNet_Task.Helpers;

namespace DotNet_Task.Services
{
    public interface IImageService
    {
        object AddImage(AddImagedto imagedto);
        List<object> GetAllImages();

    }
}
