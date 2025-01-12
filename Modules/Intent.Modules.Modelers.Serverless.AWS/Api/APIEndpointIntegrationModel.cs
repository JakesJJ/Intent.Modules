using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.Api.ApiAssociationModel", Version = "1.0")]

namespace Intent.Modelers.Serverless.AWS.Api
{
    [IntentManaged(Mode.Fully, Signature = Mode.Fully)]
    public class APIEndpointIntegrationModel : IMetadataModel
    {
        public const string SpecializationType = "API Endpoint Integration";
        public const string SpecializationTypeId = "59dc49b0-52e6-4066-a2d8-6678b9adee11";
        protected readonly IAssociation _association;
        protected APIEndpointIntegrationSourceEndModel _sourceEnd;
        protected APIEndpointIntegrationTargetEndModel _targetEnd;

        public APIEndpointIntegrationModel(IAssociation association, string requiredType = SpecializationType)
        {
            if (!requiredType.Equals(association.SpecializationType, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new Exception($"Cannot create a '{GetType().Name}' from association with specialization type '{association.SpecializationType}'. Must be of type '{SpecializationType}'");
            }
            _association = association;
        }

        public static APIEndpointIntegrationModel CreateFromEnd(IAssociationEnd associationEnd)
        {
            var association = new APIEndpointIntegrationModel(associationEnd.Association);
            return association;
        }

        public string Id => _association.Id;

        public APIEndpointIntegrationSourceEndModel SourceEnd => _sourceEnd ?? (_sourceEnd = new APIEndpointIntegrationSourceEndModel(_association.SourceEnd, this));

        public APIEndpointIntegrationTargetEndModel TargetEnd => _targetEnd ?? (_targetEnd = new APIEndpointIntegrationTargetEndModel(_association.TargetEnd, this));

        public IAssociation InternalAssociation => _association;

        public override string ToString()
        {
            return _association.ToString();
        }

        public bool Equals(APIEndpointIntegrationModel other)
        {
            return Equals(_association, other?._association);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((APIEndpointIntegrationModel)obj);
        }

        public override int GetHashCode()
        {
            return (_association != null ? _association.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public class APIEndpointIntegrationSourceEndModel : APIEndpointIntegrationEndModel
    {
        public const string SpecializationTypeId = "6c91b79e-8a09-4bf5-a479-fb13717f756c";

        public APIEndpointIntegrationSourceEndModel(IAssociationEnd associationEnd, APIEndpointIntegrationModel association) : base(associationEnd, association)
        {
        }
    }

    [IntentManaged(Mode.Fully)]
    public class APIEndpointIntegrationTargetEndModel : APIEndpointIntegrationEndModel
    {
        public const string SpecializationTypeId = "c9fe4ac2-2b12-4118-93ea-9c3c175d4368";

        public APIEndpointIntegrationTargetEndModel(IAssociationEnd associationEnd, APIEndpointIntegrationModel association) : base(associationEnd, association)
        {
        }
    }

    [IntentManaged(Mode.Fully)]
    public class APIEndpointIntegrationEndModel : ITypeReference, IMetadataModel, IHasName, IHasStereotypes
    {
        protected readonly IAssociationEnd _associationEnd;
        private readonly APIEndpointIntegrationModel _association;

        public APIEndpointIntegrationEndModel(IAssociationEnd associationEnd, APIEndpointIntegrationModel association)
        {
            _associationEnd = associationEnd;
            _association = association;
        }

        public static APIEndpointIntegrationEndModel Create(IAssociationEnd associationEnd)
        {
            var association = new APIEndpointIntegrationModel(associationEnd.Association);
            return association.TargetEnd.Id == associationEnd.Id ? (APIEndpointIntegrationEndModel)association.TargetEnd : association.SourceEnd;
        }

        public string Id => _associationEnd.Id;
        public string SpecializationType => _associationEnd.SpecializationType;
        public string SpecializationTypeId => _associationEnd.SpecializationTypeId;
        public string Name => _associationEnd.Name;
        public APIEndpointIntegrationModel Association => _association;
        public IAssociationEnd InternalAssociationEnd => _associationEnd;
        public IAssociation InternalAssociation => _association.InternalAssociation;
        public bool IsNavigable => _associationEnd.IsNavigable;
        public bool IsNullable => _associationEnd.TypeReference.IsNullable;
        public bool IsCollection => _associationEnd.TypeReference.IsCollection;
        public ICanBeReferencedType Element => _associationEnd.TypeReference.Element;
        public IEnumerable<ITypeReference> GenericTypeParameters => _associationEnd.TypeReference.GenericTypeParameters;
        public ITypeReference TypeReference => this;
        public IPackage Package => Element?.Package;
        public string Comment => _associationEnd.Comment;
        public IEnumerable<IStereotype> Stereotypes => _associationEnd.Stereotypes;

        public APIEndpointIntegrationEndModel OtherEnd()
        {
            return this.Equals(_association.SourceEnd) ? (APIEndpointIntegrationEndModel)_association.TargetEnd : (APIEndpointIntegrationEndModel)_association.SourceEnd;
        }

        public bool IsTargetEnd()
        {
            return _associationEnd.IsTargetEnd();
        }

        public bool IsSourceEnd()
        {
            return _associationEnd.IsSourceEnd();
        }

        public override string ToString()
        {
            return _associationEnd.ToString();
        }

        public bool Equals(APIEndpointIntegrationEndModel other)
        {
            return Equals(_associationEnd, other._associationEnd);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((APIEndpointIntegrationEndModel)obj);
        }

        public override int GetHashCode()
        {
            return (_associationEnd != null ? _associationEnd.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class APIEndpointIntegrationEndModelExtensions
    {
        public static bool IsAPIEndpointIntegrationEndModel(this ICanBeReferencedType type)
        {
            return IsAPIEndpointIntegrationTargetEndModel(type) || IsAPIEndpointIntegrationSourceEndModel(type);
        }

        public static APIEndpointIntegrationEndModel AsAPIEndpointIntegrationEndModel(this ICanBeReferencedType type)
        {
            return (APIEndpointIntegrationEndModel)type.AsAPIEndpointIntegrationTargetEndModel() ?? (APIEndpointIntegrationEndModel)type.AsAPIEndpointIntegrationSourceEndModel();
        }

        public static bool IsAPIEndpointIntegrationTargetEndModel(this ICanBeReferencedType type)
        {
            return type != null && type is IAssociationEnd associationEnd && associationEnd.SpecializationTypeId == APIEndpointIntegrationTargetEndModel.SpecializationTypeId;
        }

        public static APIEndpointIntegrationTargetEndModel AsAPIEndpointIntegrationTargetEndModel(this ICanBeReferencedType type)
        {
            return type.IsAPIEndpointIntegrationTargetEndModel() ? new APIEndpointIntegrationModel(((IAssociationEnd)type).Association).TargetEnd : null;
        }

        public static bool IsAPIEndpointIntegrationSourceEndModel(this ICanBeReferencedType type)
        {
            return type != null && type is IAssociationEnd associationEnd && associationEnd.SpecializationTypeId == APIEndpointIntegrationSourceEndModel.SpecializationTypeId;
        }

        public static APIEndpointIntegrationSourceEndModel AsAPIEndpointIntegrationSourceEndModel(this ICanBeReferencedType type)
        {
            return type.IsAPIEndpointIntegrationSourceEndModel() ? new APIEndpointIntegrationModel(((IAssociationEnd)type).Association).SourceEnd : null;
        }
    }
}