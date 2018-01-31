﻿using System;
using Intent.MetaModel.DTO;
using Intent.Modules.Constants;
using Intent.SoftwareFactory;
using Intent.SoftwareFactory.Engine;
using Intent.SoftwareFactory.MetaData;
using Intent.SoftwareFactory.MetaModels.UMLModel;
using Intent.SoftwareFactory.Templates;
using Intent.SoftwareFactory.VisualStudio;
using System.Collections.Generic;
using System.Linq;

namespace Intent.Modules.Application.Contracts.Mappings.Templates.Mapping
{
    partial class MappingTemplate : Intent.SoftwareFactory.Templates.IntentRoslynProjectItemTemplateBase<IDTOModel>, ITemplate, IRequiresPreProcessing, IHasTemplateDependencies, IHasNugetDependencies, IPostTemplateCreation, IHasDecorators<IMappingTemplateDecorator>
    {
        public const string Identifier = "Intent.Application.Contracts.Mapping";

        public const string ContractTemplateDependancyId = "ContractTemplateDependancyId";
        public const string DomainTemplateDependancyId = "DomainTemplateDependancyId";
        private IHasClassDetails _contractDependancy;
        private IHasClassDetails _domainDependancy;
        private ITemplateDependancy _domainTemplateDependancy;
        private ITemplateDependancy _contractTemplateDependancy;
        private IEnumerable<IMappingTemplateDecorator> _decorators;

        public MappingTemplate(IProject project, IDTOModel model)
            : base(Identifier, project, model)
        {

        }

        public override RoslynMergeConfig ConfigureRoslynMerger()
        {
            return new RoslynMergeConfig(new TemplateMetaData(Id, "1.0"));
        }

        public override IEnumerable<INugetPackageInfo> GetNugetDependencies()
        {
            return base.GetNugetDependencies().Concat(new INugetPackageInfo[] { NugetPackages.AutoMapper });
        }

        public IEnumerable<ITemplateDependancy> GetTemplateDependencies()
        {
            return new[] { _contractTemplateDependancy, _domainTemplateDependancy };
        }

        public IEnumerable<IMappingTemplateDecorator> GetDecorators()
        {
            return _decorators ?? (_decorators = Project.ResolveDecorators(this));
        }

        public string ContractTypeName => _contractDependancy.ClassName;

        public string DomainTypeName => _domainDependancy.ClassName;

        public string DecoratorUsings
        {
            get
            {
                return GetDecorators()
                    .SelectMany(x => x.Usings())
                    .Aggregate((x, y) => $"{x}{Environment.NewLine}{y}");
            }
        }

        public string GetDecoratorMembers(string contractTypeName, string domainTypeName)
        {
            return GetDecorators()
                .SelectMany(x => x.AdditionalMembers(contractTypeName, domainTypeName))
                .Select(x => $"{Environment.NewLine}{x}")
                .Aggregate((x, y) => $"{x}{y}");
        }

        public void Created()
        {
            var fileMetaData = GetMetaData();
            _contractTemplateDependancy = TemplateDependancy.OnModel<DTOModel>(fileMetaData.CustomMetaData[ContractTemplateDependancyId], (to) => to.Id == Model.Id);
            _domainTemplateDependancy = TemplateDependancy.OnModel<Class>(fileMetaData.CustomMetaData[DomainTemplateDependancyId], (to) => to.ClassId == Model.MappedClassId);
        }

        public void PreProcess()
        {
            _contractDependancy = this.Project.Application.FindTemplateInstance<IHasClassDetails>(_contractTemplateDependancy);
            if (_contractDependancy == null)
            {
                Logging.Log.Failure($"Unable to resolve template dependancy. Template : {this.Id} Depends on : {_contractTemplateDependancy.TemplateIdOrName} Model : {Model.Id}");
            }
            _domainDependancy = this.Project.Application.FindTemplateInstance<IHasClassDetails>(_domainTemplateDependancy);
            if (_domainDependancy == null)
            {
                Logging.Log.Failure($"Unable to resolve template dependancy. Template : {this.Id} Depends on : {_domainTemplateDependancy.TemplateIdOrName} Model : {Model.MappedClassId}");
            }
        }

        protected override RoslynDefaultFileMetaData DefineRoslynDefaultFileMetaData()
        {
            return new RoslynDefaultFileMetaData(
                overwriteBehaviour: OverwriteBehaviour.Always,
                fileName: "${Model.Name}Mapping",
                fileExtension: "cs",
                defaultLocationInProject: $"Mappings{(GetNamespaceParts().Any() ? "\\" + string.Join("\\", GetNamespaceParts()) : "")}",
                className: "${Model.Name}Mapping",
                @namespace: string.Join(".", new[] { "${Project.ProjectName}" }.Concat(GetNamespaceParts()))
                );
        }

        private IEnumerable<string> GetNamespaceParts()
        {
            return Model.GetFolderPath(includePackage: false).Select(x => x.GetStereotypeProperty<string>(StandardStereotypes.NamespaceProvider, "Namespace")).Where(x => x != null);
        }
    }
}
