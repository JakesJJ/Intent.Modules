using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.Api.ApiElementModel", Version = "1.0")]

namespace Intent.ModuleBuilder.Api
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class DesignerModel : IMetadataModel, IHasStereotypes, IHasName
    {
        public const string SpecializationType = "Designer";
        protected readonly IElement _element;

        [IntentManaged(Mode.Ignore)]
        public DesignerModel(IElement element, string requiredType = SpecializationType)
        {
            if (!requiredType.Equals(element.SpecializationType, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new Exception($"Cannot create a '{GetType().Name}' from element with specialization type '{element.SpecializationType}'. Must be of type '{SpecializationType}'");
            }
            _element = element;
        }

        [IntentManaged(Mode.Ignore)]
        public IntentModuleModel ParentModule => new IntentModuleModel(_element.Package);

        [IntentManaged(Mode.Fully)]
        public string Id => _element.Id;

        [IntentManaged(Mode.Fully)]
        public string Name => _element.Name;

        [IntentManaged(Mode.Fully)]
        public IEnumerable<IStereotype> Stereotypes => _element.Stereotypes;

        [IntentManaged(Mode.Fully)]
        public IElement InternalElement => _element;

        [IntentManaged(Mode.Fully)]
        public override string ToString()
        {
            return _element.ToString();
        }

        [IntentManaged(Mode.Fully)]
        public bool Equals(DesignerModel other)
        {
            return Equals(_element, other?._element);
        }

        [IntentManaged(Mode.Fully)]
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DesignerModel)obj);
        }

        [IntentManaged(Mode.Fully)]
        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }

        [IntentManaged(Mode.Fully)]
        public IList<DesignerReferenceModel> DesignerReferences => _element.ChildElements
            .GetElementsOfType(DesignerReferenceModel.SpecializationTypeId)
            .Select(x => new DesignerReferenceModel(x))
            .ToList();
        public const string SpecializationTypeId = "7f5fcc9f-c721-4a31-bfe2-7909f4289420";

        public string Comment => _element.Comment;
    }

    [IntentManaged(Mode.Fully)]
    public static class DesignerModelExtensions
    {

        public static bool IsDesignerModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == DesignerModel.SpecializationTypeId;
        }

        public static DesignerModel AsDesignerModel(this ICanBeReferencedType type)
        {
            return type.IsDesignerModel() ? new DesignerModel((IElement)type) : null;
        }
    }
}