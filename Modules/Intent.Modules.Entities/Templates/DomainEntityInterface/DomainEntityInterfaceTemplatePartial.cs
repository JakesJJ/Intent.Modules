﻿using System;
using System.Collections;
using Intent.Engine;
using Intent.Templates;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modelers.Domain.Api;
using Intent.Modules.Common;
using Intent.Modules.Common.Templates;
using Intent.Modules.Entities.Templates.DomainEntityState;
using IClass = Intent.Modelers.Domain.Api.IClass;
using IAssociationEnd = Intent.Modelers.Domain.Api.IAssociationEnd;

namespace Intent.Modules.Entities.Templates.DomainEntityInterface
{
    partial class DomainEntityInterfaceTemplate : IntentRoslynProjectItemTemplateBase<IClass>, ITemplate, IHasDecorators<DomainEntityInterfaceDecoratorBase>, ITemplatePostCreationHook
    {
        private readonly IMetadataManager _metadataManager;
        public const string Identifier = "Intent.Entities.DomainEntityInterface";
        private const string OPERATIONS_CONTEXT = "Operations";

        private readonly IList<DomainEntityInterfaceDecoratorBase> _decorators = new List<DomainEntityInterfaceDecoratorBase>();

        public DomainEntityInterfaceTemplate(IClass model, IProject project, IMetadataManager metadataManager)
            : base(Identifier, project, model)
        {
            _metadataManager = metadataManager;
        }

        public override void OnCreated()
        {
            Types.AddClassTypeSource(CSharpTypeSource.InProject(Project, DomainEntityStateTemplate.Identifier, "ICollection<{0}>"));
            Types.AddClassTypeSource(CSharpTypeSource.InProject(Project, DomainEntityInterfaceTemplate.Identifier), OPERATIONS_CONTEXT);
        }

        public override RoslynMergeConfig ConfigureRoslynMerger()
        {
            return new RoslynMergeConfig(new TemplateMetadata(Id, new TemplateVersion(1, 0)));
        }

        protected override RoslynDefaultFileMetadata DefineRoslynDefaultFileMetadata()
        {
            return new RoslynDefaultFileMetadata(
                overwriteBehaviour: OverwriteBehaviour.Always,
                fileName: "I${Model.Name}",
                fileExtension: "cs",
                defaultLocationInProject: "Domain",
                className: "I${Model.Name}",
                @namespace: "${Project.ProjectName}"
                );
        }

        public void AddDecorator(DomainEntityInterfaceDecoratorBase decorator)
        {
            _decorators.Add(decorator);
        }

        public IEnumerable<DomainEntityInterfaceDecoratorBase> GetDecorators()
        {
            return _decorators;
        }

        public string GetInterfaces(IClass @class)
        {
            var interfaces = GetDecorators().SelectMany(x => x.GetInterfaces(@class)).Distinct().ToList();
            if (Model.GetStereotypeProperty("Base Type", "Has Interface", false))
            {
                interfaces.Insert(0, GetBaseTypeInterface());
            }
            return interfaces.Any() ? " : " + interfaces.Aggregate((x, y) => x + ", " + y) : "";
        }

        private string GetBaseTypeInterface()
        {
            var typeId = Model.GetStereotypeProperty<string>("Base Type", "Type");
            if (typeId == null)
            {
                return null;
            }

            var type = _metadataManager.GetTypeDefinitions(Project.Application.Id).FirstOrDefault(x => x.Id == typeId);
            if (type != null)
            {
                return $"I{type.Name}";
            }
            throw new Exception($"Could not find Base Type for class {Model.Name}");
        }

        public string InterfaceAnnotations(IClass @class)
        {
            return GetDecorators().Aggregate(x => x.InterfaceAnnotations(@class));
        }

        public string BeforeProperties(IClass @class)
        {
            return GetDecorators().Aggregate(x => x.BeforeProperties(@class));
        }

        public string PropertyBefore(IAttribute attribute)
        {
            return GetDecorators().Aggregate(x => x.PropertyBefore(attribute));
        }

        public string PropertyAnnotations(IAttribute attribute)
        {
            return GetDecorators().Aggregate(x => x.PropertyAnnotations(attribute));
        }

        public string PropertyBefore(IAssociationEnd associationEnd)
        {
            return GetDecorators().Aggregate(x => x.PropertyBefore(associationEnd));
        }

        public string PropertyAnnotations(IAssociationEnd associationEnd)
        {
            return GetDecorators().Aggregate(x => x.PropertyAnnotations(associationEnd));
        }

        public string AttributeAccessors(IAttribute attribute)
        {
            return GetDecorators().Select(x => x.AttributeAccessors(attribute)).FirstOrDefault(x => x != null) ?? "get; set;";
        }

        public string AssociationAccessors(IAssociationEnd associationEnd)
        {
            return GetDecorators().Select(x => x.AssociationAccessors(associationEnd)).FirstOrDefault(x => x != null) ?? "get; set;";
        }

        public bool CanWriteDefaultAttribute(IAttribute attribute)
        {
            return GetDecorators().All(x => x.CanWriteDefaultAttribute(attribute));
        }

        public bool CanWriteDefaultAssociation(IAssociationEnd association)
        {
            return GetDecorators().All(x => x.CanWriteDefaultAssociation(association));
        }

        public bool CanWriteDefaultOperation(IOperation operation)
        {
            return GetDecorators().All(x => x.CanWriteDefaultOperation(operation));
        }

        public string GetParametersDefinition(IOperation operation)
        {
            return operation.Parameters.Any()
                ? operation.Parameters.Select(x => this.ConvertType(x.Type, OPERATIONS_CONTEXT) + " " + x.Name.ToCamelCase()).Aggregate((x, y) => x + ", " + y)
                : "";
        }

        public string EmitOperationReturnType(IOperation o)
        {
            if (o.ReturnType == null)
            {
                return o.IsAsync() ? "Task" : "void";
            }
            return o.IsAsync() ? $"Task<{this.ConvertType(o.ReturnType.Type, OPERATIONS_CONTEXT)}>" : this.ConvertType(o.ReturnType.Type, OPERATIONS_CONTEXT);
        }
    }
}
