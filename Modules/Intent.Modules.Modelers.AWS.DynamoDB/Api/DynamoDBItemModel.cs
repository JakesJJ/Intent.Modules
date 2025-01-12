using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.Api.ApiElementModel", Version = "1.0")]

namespace Intent.Modelers.AWS.DynamoDB.Api
{
    [IntentManaged(Mode.Fully, Signature = Mode.Fully)]
    public class DynamoDBItemModel : IMetadataModel, IHasStereotypes, IHasName
    {
        public const string SpecializationType = "DynamoDB Item";
        public const string SpecializationTypeId = "83f50394-05f3-422d-b33f-ad2b4a2a4008";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public DynamoDBItemModel(IElement element, string requiredType = SpecializationType)
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

        public IList<ScalarAttributeModel> ScalarAttributes => _element.ChildElements
            .GetElementsOfType(ScalarAttributeModel.SpecializationTypeId)
            .Select(x => new ScalarAttributeModel(x))
            .ToList();

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(DynamoDBItemModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DynamoDBItemModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class DynamoDBItemModelExtensions
    {

        public static bool IsDynamoDBItemModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == DynamoDBItemModel.SpecializationTypeId;
        }

        public static DynamoDBItemModel AsDynamoDBItemModel(this ICanBeReferencedType type)
        {
            return type.IsDynamoDBItemModel() ? new DynamoDBItemModel((IElement)type) : null;
        }
    }
}