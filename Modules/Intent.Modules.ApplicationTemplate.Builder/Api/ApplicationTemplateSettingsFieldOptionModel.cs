using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.Api.ApiElementModel", Version = "1.0")]

namespace Intent.Modules.ApplicationTemplate.Builder.Api
{
    [IntentManaged(Mode.Merge)]
    public class ApplicationTemplateSettingsFieldOptionModel : IMetadataModel, IHasStereotypes, IHasName
    {
        public const string SpecializationType = "Application Template Settings Field Option";
        public const string SpecializationTypeId = "7194651e-45da-4a0c-b1ab-0351a5c08fc8";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public ApplicationTemplateSettingsFieldOptionModel(IElement element, string requiredType = SpecializationType)
        {
            if (!requiredType.Equals(element.SpecializationType, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new Exception($"Cannot create a '{GetType().Name}' from element with specialization type '{element.SpecializationType}'. Must be of type '{SpecializationType}'");
            }
            _element = element;
        }

        public string Id => _element.Id;

        public string Name => _element.Name;

        public string Comment => _element.Comment;

        public IEnumerable<IStereotype> Stereotypes => _element.Stereotypes;

        public string Value => _element.Value;

        public IElement InternalElement => _element;

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(ApplicationTemplateSettingsFieldOptionModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ApplicationTemplateSettingsFieldOptionModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class ApplicationTemplateSettingsFieldOptionModelExtensions
    {

        public static bool IsApplicationTemplateSettingsFieldOptionModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == ApplicationTemplateSettingsFieldOptionModel.SpecializationTypeId;
        }

        public static ApplicationTemplateSettingsFieldOptionModel AsApplicationTemplateSettingsFieldOptionModel(this ICanBeReferencedType type)
        {
            return type.IsApplicationTemplateSettingsFieldOptionModel() ? new ApplicationTemplateSettingsFieldOptionModel((IElement)type) : null;
        }
    }
}