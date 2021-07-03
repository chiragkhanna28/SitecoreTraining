using Sitecore.Foundation.Domain.Models;
using Sitecore.Links;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.Foundation.Domain;

namespace Sitecore.Feature.Footer.Controllers
{
    public class FooterController: Controller
    {
        public ActionResult Index()
        {
            var footerFolder = Sitecore.Context.Database.GetItem(GlobalConstants.Paths.SettingsItemPath);
            IEnumerable<NavItem> GetNavItems(Item navRoot)
            {
                var items = new List<Item> { navRoot };
                items.AddRange(navRoot.Children.Where(item => item.DescendsFrom(GlobalConstants.TemplateIds.Contentpage)));
                var navItems = items.Skip(1).Select(item => new NavItem
                {
                    Item = item,
                    Url = LinkManager.GetItemUrl(item),
                }).ToList();
                return navItems;
            }

            var footerLinks = new NavGroup
            {
                RootItem = footerFolder,
                RootUrl = LinkManager.GetItemUrl(footerFolder),
                NavItems = GetNavItems(footerFolder)
            };
            return View(footerLinks);
        }
    }
}