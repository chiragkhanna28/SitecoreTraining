using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Items;

namespace Sitecore.Foundation.Domain.Models
{
    public class Listing
    {
        public Item ParentItem { get; set; }
        public IEnumerable<NavItem> Posts { get; set; } = Enumerable.Empty<NavItem>();
    }
}