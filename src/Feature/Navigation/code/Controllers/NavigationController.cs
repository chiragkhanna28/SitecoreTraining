using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.Foundation.Domain;
using Sitecore.Foundation.Domain.Models;
using Sitecore.Links;

namespace Sitecore.Feature.Navigation.Controllers
{
    public class NavigationController: Controller
    {
        public ActionResult Index()
        {
            Item homeItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);

            IEnumerable<NavItem> GetNavItems(Item navRoot)
            {
                var items = new List<Item> { navRoot };
                items.AddRange(navRoot.Children.Where(item => item.DescendsFrom(GlobalConstants.TemplateIds.Contentpage)));

                var navItems = items.Select(item => new NavItem
                {
                    Item = item,
                    Url = LinkManager.GetItemUrl(item),
                }).ToList();

                return navItems;
            }

            var navigation = new NavGroup
            {
                RootItem = homeItem,
                RootUrl = LinkManager.GetItemUrl(homeItem),
                NavItems = GetNavItems(homeItem)
            };

            return View(navigation);
        }
    }
}