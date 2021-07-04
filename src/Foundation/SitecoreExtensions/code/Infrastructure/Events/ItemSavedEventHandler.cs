using System;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Events;
using Sitecore.Foundation.SitecoreExtensions.Infrastructure.Pipelines;
using Sitecore.Pipelines;
using Sitecore.Web.UI.Sheer;

namespace Sitecore.Foundation.SitecoreExtensions.Infrastructure.Events
{
    public class ItemSavedEventHandler
    {
        public void OnItemSaved(object sender, EventArgs args)
        {
            Item item = Event.ExtractParameter(args, 0) as Item;
            CustomPipelineRequestArgs pipelineArgs = new CustomPipelineRequestArgs(item);
            CorePipeline.Run("CustomPipeline", pipelineArgs);
            Log.Info(pipelineArgs.Message, this);
            string message = pipelineArgs.Message;
            if (!string.IsNullOrEmpty(message))
            {
                SheerResponse.Alert(message);
            }
        }
    }
}