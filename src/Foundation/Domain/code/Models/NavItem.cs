using Sitecore.Data.Items;

namespace Sitecore.Foundation.Domain.Models
{
    public class NavItem
    {
        public Item Item { get; set; }
        public string Url { get; set; }
    }
}