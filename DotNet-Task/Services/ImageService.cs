using DotNet_Task.Data;
using DotNet_Task.Helpers;
using DotNet_Task.Models;

namespace DotNet_Task.Services
{
    public class ImageService : IImageService

    {
        private readonly AppDbContext context;
        private readonly ILogger<ImageService> logger;

        public ImageService(AppDbContext context, ILogger<ImageService> logger)
        {
            this.context = context;
            this.logger = logger;

        }
        public object AddImage(AddImagedto imagedto)
        {
            var productExist = context.Products.FirstOrDefault(p => p.ProductId == imagedto.ProductId);

            if (productExist == null)
            {
                return null;
            }

            var img = new Image()
            {
                ImageUrl = imagedto.ImageUrl,
                ProductId = imagedto.ProductId

            };

            try
            {
                context.Images.Add(img);

                var imgProjected = new
                {
                    img.ImageId,
                    img.ImageUrl,
                    img.ProductId

                };

                return imgProjected;
            }
            catch (Exception ex)
            {
                logger.LogError("Exception", ex);
                throw;
            }

        }

        public List<object> GetAllImages()
        {
            var images = context.Images.Select(i => new { i.ImageId, i.ImageUrl, i.ProductId }).ToList<object>();

            return images;
        }


    }
}
