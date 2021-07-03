using System.Collections.Generic;
using Sitecore.Data.Items;

namespace Sitecore.Foundation.Domain.Models
{
    public class NavGroup
    {
        public Item RootItem { get; set; }
        public string RootUrl { get; set; }
        public IEnumerable<NavItem> NavItems { get; set; }
    }
}