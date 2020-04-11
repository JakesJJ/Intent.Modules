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
    public class ElementMappingModel : IHasStereotypes, IMetadataModel
    {
        public const string SpecializationType = "Element Mapping";
        private readonly IElement _element;

        public ElementMappingModel(IElement element)
        {
            if (!SpecializationType.Equals(element.SpecializationType, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new Exception($"Cannot create a 'ElementMappingModel' from element with specialization type '{element.SpecializationType}'. Must be of type '{SpecializationType}'");
            }
            _element = element;
        }

        public string Id => _element.Id;

        public string Name => _element.Name;

        public IEnumerable<IStereotype> Stereotypes => _element.Stereotypes;

        [IntentManaged(Mode.Fully)]
        public MappingCriteriaModel Criteria => _element.ChildElements
            .Where(x => x.SpecializationType == Api.MappingCriteriaModel.SpecializationType)
            .Select(x => new MappingCriteriaModel(x))
            .SingleOrDefault();
        [IntentManaged(Mode.Fully)]
        public MappingOutputModel Output => _element.ChildElements
            .Where(x => x.SpecializationType == Api.MappingOutputModel.SpecializationType)
            .Select(x => new MappingOutputModel(x))
            .SingleOrDefault();
        [IntentManaged(Mode.Fully)]
        public IList<ElementMappingModel> ChildMappings => _element.ChildElements
            .Where(x => x.SpecializationType == Api.ElementMappingModel.SpecializationType)
            .Select(x => new ElementMappingModel(x))
            .ToList<ElementMappingModel>();

        protected bool Equals(ElementMappingModel other)
        {
            return Equals(_element, other._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ElementMappingModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }
}