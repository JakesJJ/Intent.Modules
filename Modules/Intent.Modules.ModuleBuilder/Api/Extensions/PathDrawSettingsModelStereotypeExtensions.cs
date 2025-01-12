using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.Api.ApiElementModelExtensions", Version = "1.0")]

namespace Intent.ModuleBuilder.Api
{
    public static class PathDrawSettingsModelStereotypeExtensions
    {
        public static PathSettings GetPathSettings(this PathDrawSettingsModel model)
        {
            var stereotype = model.GetStereotype("Path Settings");
            return stereotype != null ? new PathSettings(stereotype) : null;
        }

        public static bool HasPathSettings(this PathDrawSettingsModel model)
        {
            return model.HasStereotype("Path Settings");
        }

        public static bool TryGetPathSettings(this PathDrawSettingsModel model, out PathSettings stereotype)
        {
            if (!HasPathSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new PathSettings(model.GetStereotype("Path Settings"));
            return true;
        }


        public class PathSettings
        {
            private IStereotype _stereotype;

            public PathSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public string Path()
            {
                return _stereotype.GetProperty<string>("Path");
            }

            public string Condition()
            {
                return _stereotype.GetProperty<string>("Condition");
            }

            public string LineColor()
            {
                return _stereotype.GetProperty<string>("Line Color");
            }

            public string LineWidth()
            {
                return _stereotype.GetProperty<string>("Line Width");
            }

            public string LineDashArray()
            {
                return _stereotype.GetProperty<string>("Line Dash Array");
            }

            public string FillColor()
            {
                return _stereotype.GetProperty<string>("Fill Color");
            }

        }

    }
}