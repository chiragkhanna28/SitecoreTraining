using Sitecore.Data.Fields;
using Sitecore.Foundation.Domain;
using System;

namespace Sitecore.Foundation.SitecoreExtensions.Infrastructure.Pipelines
{
    public class CheckValidItemProcessor : CustomPipelineProcessor
    {
        public override void Process(CustomPipelineRequestArgs args)
        {
            var dateField = (DateField)args.Item.Fields["Date Time"];
            if (!args.Item.DescendsFrom(GlobalConstants.TemplateIds.ReviewBlogPage))
            {
                return;
            }
            if (dateField == null || dateField.DateTime == DateTime.MinValue)
            {
                args.Valid = false;
                args.AddMessage("Date has not been set");
            }
        }
    }
}