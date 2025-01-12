using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.Modules.Common.Types.Api;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.Api.ApiElementModel", Version = "1.0")]

namespace Intent.ModuleBuilder.Api
{
    [IntentManaged(Mode.Merge)]
    public partial class TemplateDecoratorModel : IMetadataModel, IHasStereotypes, IHasName, IHasTypeReference, IHasFolder
    {
        public const string SpecializationType = "Template Decorator";
        public const string SpecializationTypeId = "f0f46278-29ea-42bd-9206-0e7034f623bc";
        protected readonly IElement _element;

        [IntentManaged(Mode.Ignore)]
        public TemplateDecoratorModel(IElement element, string requiredType = SpecializationType)
        {
            if (!requiredType.Equals(element.SpecializationType, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new Exception($"Cannot create a '{GetType().Name}' from element with specialization type '{element.SpecializationType}'. Must be of type '{SpecializationType}'");
            }
            _element = element;
            Folder = _element.ParentElement?.SpecializationTypeId == FolderModel.SpecializationTypeId ? new FolderModel(_element.ParentElement) : null;
        }

        public string Id => _element.Id;

        public string Name => _element.Name;

        public IEnumerable<IStereotype> Stereotypes => _element.Stereotypes;

        public ITypeReference TypeReference => _element.TypeReference;

        public IElement InternalElement => _element;

        [IntentManaged(Mode.Ignore)]
        public IntentModuleModel GetModule()
        {
            return new IntentModuleModel(_element.Package);
        }

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(TemplateDecoratorModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TemplateDecoratorModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }

        public string Comment => _element.Comment;

        public FolderModel Folder { get; }
    }

    [IntentManaged(Mode.Fully)]
    public static class TemplateDecoratorModelExtensions
    {

        public static bool IsTemplateDecoratorModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == TemplateDecoratorModel.SpecializationTypeId;
        }

        public static TemplateDecoratorModel AsTemplateDecoratorModel(this ICanBeReferencedType type)
        {
            return type.IsTemplateDecoratorModel() ? new TemplateDecoratorModel((IElement)type) : null;
        }
    }
}