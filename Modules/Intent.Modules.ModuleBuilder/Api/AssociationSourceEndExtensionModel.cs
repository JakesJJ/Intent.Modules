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
    public class AssociationSourceEndExtensionModel : IMetadataModel, IHasStereotypes, IHasName
    {
        public const string SpecializationType = "Association Source End Extension";
        public const string SpecializationTypeId = "66ec1dcd-a0c3-45ac-ad62-f2d9d7064bb3";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public AssociationSourceEndExtensionModel(IElement element, string requiredType = SpecializationType)
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

        public IElement InternalElement => _element;

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(AssociationSourceEndExtensionModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AssociationSourceEndExtensionModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class AssociationSourceEndExtensionModelExtensions
    {

        public static bool IsAssociationSourceEndExtensionModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == AssociationSourceEndExtensionModel.SpecializationTypeId;
        }

        public static AssociationSourceEndExtensionModel AsAssociationSourceEndExtensionModel(this ICanBeReferencedType type)
        {
            return type.IsAssociationSourceEndExtensionModel() ? new AssociationSourceEndExtensionModel((IElement)type) : null;
        }
    }
}