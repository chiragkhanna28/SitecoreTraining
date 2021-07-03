using Sitecore.Data.Fields;
using Sitecore.Feature.ImageGallery.Models;
using Sitecore.Mvc.Presentation;
using Sitecore.Resources.Media;
using System.Linq;
using System.Web.Mvc;

namespace Sitecore.Feature.ImageGallery.Controllers
{
    public class ImageGalleryController : Controller
    {
        public ActionResult Index()
        {
            var dataSourceID = RenderingContext.CurrentOrNull.Rendering.DataSource;
            var imgList = new ImageGalleryUrls();
            if (dataSourceID != null)
            {
                var dataSource = Sitecore.Context.Database.GetItem(dataSourceID);
                if (dataSource != null)
                {
                    MultilistField listofImages = dataSource.Fields["Images"];
                    imgList.ImageUrls = listofImages.GetItems().Select(item => MediaManager.GetMediaUrl(item));
                }
            }
            return View(imgList);
        }
    }
}