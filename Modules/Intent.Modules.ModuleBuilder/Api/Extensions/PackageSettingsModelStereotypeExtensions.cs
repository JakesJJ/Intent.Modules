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
    public static class PackageSettingsModelStereotypeExtensions
    {
        public static PackageSettings GetPackageSettings(this PackageSettingsModel model)
        {
            var stereotype = model.GetStereotype("Package Settings");
            return stereotype != null ? new PackageSettings(stereotype) : null;
        }

        public static bool HasPackageSettings(this PackageSettingsModel model)
        {
            return model.HasStereotype("Package Settings");
        }

        public static bool TryGetPackageSettings(this PackageSettingsModel model, out PackageSettings stereotype)
        {
            if (!HasPackageSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new PackageSettings(model.GetStereotype("Package Settings"));
            return true;
        }


        public class PackageSettings
        {
            private IStereotype _stereotype;

            public PackageSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public string DefaultNameFunction()
            {
                return _stereotype.GetProperty<string>("Default Name Function");
            }

            public IIconModel Icon()
            {
                return _stereotype.GetProperty<IIconModel>("Icon");
            }

            public SortingOptions Sorting()
            {
                return new SortingOptions(_stereotype.GetProperty<string>("Sorting"));
            }

            public class SortingOptions
            {
                public readonly string Value;

                public SortingOptions(string value)
                {
                    Value = value;
                }

                public SortingOptionsEnum AsEnum()
                {
                    switch (Value)
                    {
                        case "Manually":
                            return SortingOptionsEnum.Manually;
                        case "By type, then manually":
                            return SortingOptionsEnum.ByTypeThenManually;
                        case "By type, then by name":
                            return SortingOptionsEnum.ByTypeThenByName;
                        case "By name":
                            return SortingOptionsEnum.ByName;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                public bool IsManually()
                {
                    return Value == "Manually";
                }
                public bool IsByTypeThenManually()
                {
                    return Value == "By type, then manually";
                }
                public bool IsByTypeThenByName()
                {
                    return Value == "By type, then by name";
                }
                public bool IsByName()
                {
                    return Value == "By name";
                }
            }

            public enum SortingOptionsEnum
            {
                Manually,
                ByTypeThenManually,
                ByTypeThenByName,
                ByName
            }
        }

    }
}