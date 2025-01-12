using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.Api.ApiElementModel", Version = "1.0")]

namespace Intent.ModuleBuilder.Api
{
    [IntentManaged(Mode.Merge)]
    public partial class TemplateDecoratorContractModel : IMetadataModel, IHasStereotypes, IHasName
    {
        public const string SpecializationType = "Template Decorator Contract";
        public const string SpecializationTypeId = "ac1da322-377e-45cf-a2d9-d147a4d91457";
        protected readonly IElement _element;

        [IntentManaged(Mode.Ignore)]
        public TemplateDecoratorContractModel(IElement element, string requiredType = SpecializationType)
        {
            if (!requiredType.Equals(element.SpecializationType, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new Exception($"Cannot create a '{GetType().Name}' from element with specialization type '{element.SpecializationType}'. Must be of type '{SpecializationType}'");
            }
            _element = element;
        }

        public string Id => _element.Id;

        public string Name => _element.Name;

        public IEnumerable<IStereotype> Stereotypes => _element.Stereotypes;

        public IElement InternalElement => _element;

        [IntentManaged(Mode.Ignore)]
        public TemplateRegistrationModel Template => new TemplateRegistrationModel(InternalElement.ParentElement);

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(TemplateDecoratorContractModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TemplateDecoratorContractModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }

        public string Comment => _element.Comment;
    }

    [IntentManaged(Mode.Fully)]
    public static class TemplateDecoratorContractModelExtensions
    {

        public static bool IsTemplateDecoratorContractModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == TemplateDecoratorContractModel.SpecializationTypeId;
        }

        public static TemplateDecoratorContractModel AsTemplateDecoratorContractModel(this ICanBeReferencedType type)
        {
            return type.IsTemplateDecoratorContractModel() ? new TemplateDecoratorContractModel((IElement)type) : null;
        }
    }
}