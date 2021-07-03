using Sitecore.Foundation.Domain.Models;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using System.Linq;
using System.Web.Mvc;

namespace Sitecore.Feature.ArticleListing.Controllers
{
    public class ArticleListingController: Controller
    {
        public ActionResult Index()
        {
            var dataSourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;
            var articleList = new Listing();

            if (dataSourceId != null)
            {
                var dataSource = Sitecore.Context.Database.GetItem(dataSourceId);
                if (dataSource != null)
                {
                    var listofArticles = dataSource.Children;
                    articleList.Posts = listofArticles.Select(item => new NavItem
                    {
                        Item = item,
                        Url = LinkManager.GetItemUrl(item),
                    }).ToList();
                }
            }
            return View(articleList);
        }
    }
}