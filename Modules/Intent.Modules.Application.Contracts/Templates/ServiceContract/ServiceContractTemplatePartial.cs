﻿using Intent.Modules.Constants;
using Intent.Engine;
using Intent.Templates;
using System.Collections.Generic;
using System.Linq;
using System;
using Intent.Metadata.Models;
using Intent.Modelers.Services.Api;
using Intent.Modules.Application.Contracts.Templates.DTO;
using Intent.Modules.Common;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.VisualStudio;
using Intent.SoftwareFactory.Templates;

namespace Intent.Modules.Application.Contracts.Templates.ServiceContract
{
    partial class ServiceContractTemplate : IntentRoslynProjectItemTemplateBase<IServiceModel>, ITemplate, IPostTemplateCreation, IHasTemplateDependencies, IHasNugetDependencies, IHasDecorators<IServiceContractAttributeDecorator>
    {
        public const string IDENTIFIER = "Intent.Application.Contracts.ServiceContract";

        private readonly DecoratorDispatcher<IServiceContractAttributeDecorator> _decoratorDispatcher;

        public ServiceContractTemplate(IProject project, IServiceModel model, string identifier = IDENTIFIER)
            : base(identifier, project, model)
        {
            _decoratorDispatcher = new DecoratorDispatcher<IServiceContractAttributeDecorator>(project.ResolveDecorators<IServiceContractAttributeDecorator>);
        }

        public void Created()
        {
            Types.AddClassTypeSource(CSharpTypeSource.InProject(Project, DTOTemplate.IDENTIFIER, "List<{0}>"));
        }

        public IEnumerable<ITemplateDependency> GetTemplateDependencies()
        {
            return new ITemplateDependency[] { };
        }

        public override IEnumerable<INugetPackageInfo> GetNugetDependencies()
        {
            return new List<INugetPackageInfo>()
            {
                NugetPackages.IntentRoslynWeaverAttributes,
            };
        }

        public override RoslynMergeConfig ConfigureRoslynMerger()
        {
            return new RoslynMergeConfig(new TemplateMetaData(Id, "1.0"));
        }

        public IEnumerable<IServiceContractAttributeDecorator> GetDecorators()
        {
            return _decoratorDispatcher.GetDecorators();
        }

        protected override RoslynDefaultFileMetaData DefineRoslynDefaultFileMetaData()
        {
            return new RoslynDefaultFileMetaData(
                overwriteBehaviour: OverwriteBehaviour.Always,
                fileName: "I${Model.Name}",
                fileExtension: "cs",
                defaultLocationInProject: string.Join("/", GetNamespaceParts().DefaultIfEmpty("ServiceContracts")),
                className: "I${Model.Name}",
                @namespace: "${FolderBasedNamespace}");
        }

        public string FolderBasedNamespace => string.Join(".", new[] { Project.Name }.Concat(GetNamespaceParts()));

        public string ContractAttributes()
        {
            return _decoratorDispatcher.Dispatch(x => x.ContractAttributes(Model));
        }

        public string OperationAttributes(IOperation operation)
        {
            return _decoratorDispatcher.Dispatch(x => x.OperationAttributes(Model, operation));
        }

        private IEnumerable<string> GetNamespaceParts()
        {
            return Model
                .GetFolderPath(includePackage: false)
                .Select(x => x.GetStereotypeProperty<string>(StandardStereotypes.NamespaceProvider, "Namespace") ?? x.Name)
                .Where(x => !string.IsNullOrWhiteSpace(x));
        }


        private string GetOperationDefinitionParameters(IOperation o)
        {
            if (!o.Parameters.Any())
            {
                return "";
            }
            return o.Parameters.Select(x => $"{GetTypeName(x.Type)} {x.Name}").Aggregate((x, y) => x + ", " + y);
        }

        private string GetOperationReturnType(IOperation o)
        {
            if (o.ReturnType == null)
            {
                return o.IsAsync() ? "Task" : "void";
            }
            return o.IsAsync() ? $"Task<{GetTypeName(o.ReturnType.Type)}>" : GetTypeName(o.ReturnType.Type);
        }

        private string GetTypeName(ITypeReference typeInfo)
        {
            var result = NormalizeNamespace(Types.Get(typeInfo, "List<{0}>"));
            //if (typeInfo.IsCollection && typeInfo.Type != ReferenceType.ClassType)
            //{
            //    result = string.Format(GetCollectionTypeFormatConfig(), result);
            //}
            // Don't check for nullables here because the type resolution system will take care of language specific nullables

            return result;
        }

        private string GetCollectionTypeFormatConfig()
        {
            var format = FileMetaData.CustomMetaData["Collection Type Format"];
            if (string.IsNullOrEmpty(format))
            {
                throw new Exception("Collection Type Format not specified in module configuration");
            }
            return format;
        }
    }
}
