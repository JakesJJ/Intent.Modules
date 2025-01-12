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
    public static class ElementMappingModelStereotypeExtensions
    {
        public static BehaviourSettings GetBehaviourSettings(this ElementMappingModel model)
        {
            var stereotype = model.GetStereotype("Behaviour Settings");
            return stereotype != null ? new BehaviourSettings(stereotype) : null;
        }

        public static bool HasBehaviourSettings(this ElementMappingModel model)
        {
            return model.HasStereotype("Behaviour Settings");
        }

        public static bool TryGetBehaviourSettings(this ElementMappingModel model, out BehaviourSettings stereotype)
        {
            if (!HasBehaviourSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new BehaviourSettings(model.GetStereotype("Behaviour Settings"));
            return true;
        }

        public static CriteriaSettings GetCriteriaSettings(this ElementMappingModel model)
        {
            var stereotype = model.GetStereotype("Criteria Settings");
            return stereotype != null ? new CriteriaSettings(stereotype) : null;
        }

        public static bool HasCriteriaSettings(this ElementMappingModel model)
        {
            return model.HasStereotype("Criteria Settings");
        }

        public static bool TryGetCriteriaSettings(this ElementMappingModel model, out CriteriaSettings stereotype)
        {
            if (!HasCriteriaSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new CriteriaSettings(model.GetStereotype("Criteria Settings"));
            return true;
        }

        public static OutputSettings GetOutputSettings(this ElementMappingModel model)
        {
            var stereotype = model.GetStereotype("Output Settings");
            return stereotype != null ? new OutputSettings(stereotype) : null;
        }

        public static bool HasOutputSettings(this ElementMappingModel model)
        {
            return model.HasStereotype("Output Settings");
        }

        public static bool TryGetOutputSettings(this ElementMappingModel model, out OutputSettings stereotype)
        {
            if (!HasOutputSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new OutputSettings(model.GetStereotype("Output Settings"));
            return true;
        }


        public class BehaviourSettings
        {
            private IStereotype _stereotype;

            public BehaviourSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public bool AutoSelectChildren()
            {
                return _stereotype.GetProperty<bool>("Auto-select Children");
            }

            public class AutoSelectChildrenOptions
            {
                public readonly string Value;

                public AutoSelectChildrenOptions(string value)
                {
                    Value = value;
                }

                public AutoSelectChildrenOptionsEnum AsEnum()
                {
                    switch (Value)
                    {
                        case "Yes":
                            return AutoSelectChildrenOptionsEnum.Yes;
                        case "No":
                            return AutoSelectChildrenOptionsEnum.No;
                        case "Not Applicable":
                            return AutoSelectChildrenOptionsEnum.NotApplicable;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                public bool IsYes()
                {
                    return Value == "Yes";
                }
                public bool IsNo()
                {
                    return Value == "No";
                }
                public bool IsNotApplicable()
                {
                    return Value == "Not Applicable";
                }
            }

            public enum AutoSelectChildrenOptionsEnum
            {
                Yes,
                No,
                NotApplicable
            }
        }

        public class CriteriaSettings
        {
            private IStereotype _stereotype;

            public CriteriaSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public IElement FromType()
            {
                return _stereotype.GetProperty<IElement>("From Type");
            }

            public HasTypeReferenceOptions HasTypeReference()
            {
                return new HasTypeReferenceOptions(_stereotype.GetProperty<string>("Has Type-Reference"));
            }

            public HasChildrenOptions HasChildren()
            {
                return new HasChildrenOptions(_stereotype.GetProperty<string>("Has Children"));
            }

            public IsCollectionOptions IsCollection()
            {
                return new IsCollectionOptions(_stereotype.GetProperty<string>("Is Collection"));
            }

            public class HasTypeReferenceOptions
            {
                public readonly string Value;

                public HasTypeReferenceOptions(string value)
                {
                    Value = value;
                }

                public HasTypeReferenceOptionsEnum AsEnum()
                {
                    switch (Value)
                    {
                        case "Yes":
                            return HasTypeReferenceOptionsEnum.Yes;
                        case "No":
                            return HasTypeReferenceOptionsEnum.No;
                        case "Not Applicable":
                            return HasTypeReferenceOptionsEnum.NotApplicable;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                public bool IsYes()
                {
                    return Value == "Yes";
                }
                public bool IsNo()
                {
                    return Value == "No";
                }
                public bool IsNotApplicable()
                {
                    return Value == "Not Applicable";
                }
            }

            public enum HasTypeReferenceOptionsEnum
            {
                Yes,
                No,
                NotApplicable
            }
            public class HasChildrenOptions
            {
                public readonly string Value;

                public HasChildrenOptions(string value)
                {
                    Value = value;
                }

                public HasChildrenOptionsEnum AsEnum()
                {
                    switch (Value)
                    {
                        case "Yes":
                            return HasChildrenOptionsEnum.Yes;
                        case "No":
                            return HasChildrenOptionsEnum.No;
                        case "Not Applicable":
                            return HasChildrenOptionsEnum.NotApplicable;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                public bool IsYes()
                {
                    return Value == "Yes";
                }
                public bool IsNo()
                {
                    return Value == "No";
                }
                public bool IsNotApplicable()
                {
                    return Value == "Not Applicable";
                }
            }

            public enum HasChildrenOptionsEnum
            {
                Yes,
                No,
                NotApplicable
            }
            public class IsCollectionOptions
            {
                public readonly string Value;

                public IsCollectionOptions(string value)
                {
                    Value = value;
                }

                public IsCollectionOptionsEnum AsEnum()
                {
                    switch (Value)
                    {
                        case "Yes":
                            return IsCollectionOptionsEnum.Yes;
                        case "No":
                            return IsCollectionOptionsEnum.No;
                        case "Not Applicable":
                            return IsCollectionOptionsEnum.NotApplicable;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                public bool IsYes()
                {
                    return Value == "Yes";
                }
                public bool IsNo()
                {
                    return Value == "No";
                }
                public bool IsNotApplicable()
                {
                    return Value == "Not Applicable";
                }
            }

            public enum IsCollectionOptionsEnum
            {
                Yes,
                No,
                NotApplicable
            }
        }

        public class OutputSettings
        {
            private IStereotype _stereotype;

            public OutputSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public ChildMappingModeOptions ChildMappingMode()
            {
                return new ChildMappingModeOptions(_stereotype.GetProperty<string>("Child Mapping Mode"));
            }

            public IElement ToType()
            {
                return _stereotype.GetProperty<IElement>("To Type");
            }

            public IElement UseMappingSettings()
            {
                return _stereotype.GetProperty<IElement>("Use Mapping Settings");
            }

            public class ChildMappingModeOptions
            {
                public readonly string Value;

                public ChildMappingModeOptions(string value)
                {
                    Value = value;
                }

                public ChildMappingModeOptionsEnum AsEnum()
                {
                    switch (Value)
                    {
                        case "Map to Type":
                            return ChildMappingModeOptionsEnum.MapToType;
                        case "Traverse":
                            return ChildMappingModeOptionsEnum.Traverse;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                public bool IsMapToType()
                {
                    return Value == "Map to Type";
                }
                public bool IsTraverse()
                {
                    return Value == "Traverse";
                }
            }

            public enum ChildMappingModeOptionsEnum
            {
                MapToType,
                Traverse
            }
        }

    }
}