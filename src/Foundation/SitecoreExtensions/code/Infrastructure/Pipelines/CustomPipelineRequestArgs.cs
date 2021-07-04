using Sitecore.Pipelines;
using Sitecore.Data.Items;

namespace Sitecore.Foundation.SitecoreExtensions.Infrastructure.Pipelines
{
    public class CustomPipelineRequestArgs : PipelineArgs
    {
        public bool Valid { get; set; } = false;
        public Item Item { get; set; } = null;
        public CustomPipelineRequestArgs(Item item)
        {
            Item = item;
        }
    }
}