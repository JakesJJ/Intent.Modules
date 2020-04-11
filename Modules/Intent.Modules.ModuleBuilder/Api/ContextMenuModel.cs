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
    public class ContextMenuModel
        : IHasStereotypes, IMetadataModel
    {
        public const string SpecializationType = "Context Menu";
        private readonly IElement _element;

        public ContextMenuModel(IElement element)
        {
            if (element.SpecializationType != SpecializationType)
            {
                throw new ArgumentException($"Invalid element type {element.SpecializationType}", nameof(element));
            }
            _element = element;
            TypeOrder = element.ChildElements.Select(x => new TypeOrder(x)).ToList();
        }

        public string Id => _element.Id;
        public string Name => _element.Name;
        public IEnumerable<IStereotype> Stereotypes => _element.Stereotypes;

        [IntentManaged(Mode.Fully)]
        public IList<CreationOptionModel> CreationOptions => _element.ChildElements
            .Where(x => x.SpecializationType == Api.CreationOptionModel.SpecializationType)
            .Select(x => new CreationOptionModel(x))
            .ToList<CreationOptionModel>();
        public IList<TypeOrder> TypeOrder { get; }

        protected bool Equals(ContextMenuModel other)
        {
            return Equals(_element, other._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ContextMenuModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }
}