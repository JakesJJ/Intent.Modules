using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("ModuleBuilder.Templates.Api.ApiModelImplementationTemplate", Version = "1.0")]

namespace Intent.Modules.ModuleBuilder.Api
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class DesignersFolderModel : IHasStereotypes, IMetadataModel
    {
        public const string SpecializationType = "Designers Folder";
        protected readonly IElement _element;

        public DesignersFolderModel(IElement element)
        {
            if (!SpecializationType.Equals(element.SpecializationType, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new Exception($"Cannot create a 'DesignersFolderModel' from element with specialization type '{element.SpecializationType}'. Must be of type '{SpecializationType}'");
            }
            _element = element;
        }

        public string Id => _element.Id;

        public string Name => _element.Name;

        public IEnumerable<IStereotype> Stereotypes => _element.Stereotypes;

        [IntentManaged(Mode.Fully)]
        public IList<DesignerModel> Designers => _element.ChildElements
            .Where(x => x.SpecializationType == Api.DesignerModel.SpecializationType)
            .Select(x => new DesignerModel(x))
            .ToList<DesignerModel>();

        [IntentManaged(Mode.Fully)]
        public bool Equals(DesignersFolderModel other)
        {
            return Equals(_element, other._element);
        }

        [IntentManaged(Mode.Fully)]
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DesignersFolderModel)obj);
        }

        [IntentManaged(Mode.Fully)]
        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }

        [IntentManaged(Mode.Fully)]
        public IList<DesignerExtensionModel> DesignerExtensions => _element.ChildElements
            .Where(x => x.SpecializationType == Api.DesignerExtensionModel.SpecializationType)
            .Select(x => new DesignerExtensionModel(x))
            .ToList<DesignerExtensionModel>();
    }
}