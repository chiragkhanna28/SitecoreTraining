using System.Collections.Generic;

namespace Sitecore.Feature.ImageGallery.Models
{
    public class ImageGalleryUrls : Mvc.Presentation.RenderingModel
    {
        public IEnumerable<string> ImageUrls { get; set; }
    }
}