using System.Collections.Generic;
using System.Linq;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("ModuleBuilder.Templates.Api.ApiMetadataProviderExtensions", Version = "1.0")]

namespace Intent.Modules.ModuleBuilder.Html.Api
{
    public static class ApiMetadataProviderExtensions
    {
        public static IList<HtmlFileTemplateModel> GetHtmlFileTemplateModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(HtmlFileTemplateModel.SpecializationTypeId)
                .Select(x => new HtmlFileTemplateModel(x))
                .ToList();
        }

    }
}