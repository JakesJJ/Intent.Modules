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
    public static class IntentModuleModelStereotypeExtensions
    {
        public static ModuleSettings GetModuleSettings(this IntentModuleModel model)
        {
            var stereotype = model.GetStereotype("Module Settings");
            return stereotype != null ? new ModuleSettings(stereotype) : null;
        }

        public static bool HasModuleSettings(this IntentModuleModel model)
        {
            return model.HasStereotype("Module Settings");
        }

        public static bool TryGetModuleSettings(this IntentModuleModel model, out ModuleSettings stereotype)
        {
            if (!HasModuleSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new ModuleSettings(model.GetStereotype("Module Settings"));
            return true;
        }


        public class ModuleSettings
        {
            private IStereotype _stereotype;

            public ModuleSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public string Version()
            {
                return _stereotype.GetProperty<string>("Version");
            }

            public IIconModel Icon()
            {
                return _stereotype.GetProperty<IIconModel>("Icon");
            }

            public string APINamespace()
            {
                return _stereotype.GetProperty<string>("API Namespace");
            }

            public string NuGetPackageId()
            {
                return _stereotype.GetProperty<string>("NuGet Package Id");
            }

            public string NuGetPackageVersion()
            {
                return _stereotype.GetProperty<string>("NuGet Package Version");
            }

            public bool IncludeInModule()
            {
                return _stereotype.GetProperty<bool>("Include in Module");
            }

            public IElement[] ReferenceInDesigner()
            {
                return _stereotype.GetProperty<IElement[]>("Reference in Designer") ?? new IElement[0];
            }

        }

    }
}