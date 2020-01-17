﻿using System.Collections.Generic;
using System.Linq;
using Intent.Engine;
using Intent.Modelers.Domain.Api;
using Intent.Modules.Common;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.VisualStudio;
using Intent.Templates;

namespace Intent.Modules.Entities.Repositories.Api.Templates.EntityRepositoryInterface
{
    partial class EntityRepositoryInterfaceTemplate : IntentRoslynProjectItemTemplateBase<IClass>, ITemplate, IHasTemplateDependencies, ITemplatePostCreationHook
    {
        public const string Identifier = "Intent.Entities.Repositories.Api.EntityInterface";
        private ITemplateDependency _entityStateTemplateDependancy;
        private ITemplateDependency _entityInterfaceTemplateDependancy;

        public EntityRepositoryInterfaceTemplate(IClass model, IProject project)
            : base(Identifier, project, model)
        {
        }

        public override void OnCreated()
        {
            _entityStateTemplateDependancy = TemplateDependency.OnModel<IClass>(GetMetadata().CustomMetadata["Entity Template Id"], (to) => to.Id == Model.Id);
            _entityInterfaceTemplateDependancy = TemplateDependency.OnModel<IClass>(GetMetadata().CustomMetadata["Entity Interface Template Id"], (to) => to.Id == Model.Id);
        }

        public string EntityStateName => Project.FindTemplateInstance<IHasClassDetails>(_entityStateTemplateDependancy)?.ClassName ?? Model.Name;

        public string EntityInterfaceName => Project.FindTemplateInstance<IHasClassDetails>(_entityInterfaceTemplateDependancy)?.ClassName ?? $"I{Model.Name}";

        public string PrimaryKeyType => Types.Get(Model.Attributes.FirstOrDefault(x => x.HasStereotype("Primary Key"))?.Type) ?? "Guid";

        public override RoslynMergeConfig ConfigureRoslynMerger()
        {
            return new RoslynMergeConfig(new TemplateMetadata(Id, new TemplateVersion(1, 0)));
        }

        protected override RoslynDefaultFileMetadata DefineRoslynDefaultFileMetadata()
        {
            return new RoslynDefaultFileMetadata(
                overwriteBehaviour: OverwriteBehaviour.Always,
                fileName: "I${Model.Name}Repository",
                fileExtension: "cs",
                defaultLocationInProject: "Repositories",
                className: "I${Model.Name}Repository",
                @namespace: "${Project.ProjectName}"
                );
        }

        public IEnumerable<ITemplateDependency> GetTemplateDependencies()
        {
            return new[]
            {
                _entityInterfaceTemplateDependancy,
                _entityStateTemplateDependancy
            };
        }

        public override IEnumerable<INugetPackageInfo> GetNugetDependencies()
        {
            return new[]
                {
                    new NugetPackageInfo("Intent.Framework.Domain", "1.0.0"),
                }
                .Union(base.GetNugetDependencies())
                .ToArray();
        }
    }
}
