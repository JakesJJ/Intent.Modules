﻿using Intent.Modules.EntityFramework.Templates.DbContext;
using Intent.Engine;
using Intent.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Modules.Common;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.VisualStudio;
using Intent.SoftwareFactory;
using Intent.SoftwareFactory.Templates;
using Intent.Utils;

namespace Intent.Modules.EntityFramework.Migrations.Templates.DbMigrationsConfiguration
{
    partial class DbMigrationsConfigurationTemplate : IntentRoslynProjectItemTemplateBase, ITemplate, IHasNugetDependencies, IHasTemplateDependencies, IHasDecorators<IMigrationSeedDecorator>
    {
        public const string Identifier = "Intent.EntityFramework.Migrations.DbMigrationsConfiguration";

        private string _dbContextName;
        private string _dbContextNamespace;
        private IEnumerable<IMigrationSeedDecorator> _decorators;
        private readonly ITracing _log = Logging.Log;

        public DbMigrationsConfigurationTemplate(IProject project)
            : base(Identifier, project)
        {
        }

        public string DbContextVariableName => "dbContext";

        protected override RoslynDefaultFileMetaData DefineRoslynDefaultFileMetaData()
        {
            return new RoslynDefaultFileMetaData(
                overwriteBehaviour: OverwriteBehaviour.Always,
                fileName: $"{Project.ApplicationName()}DbContextConfiguration".Replace(".", string.Empty),
                fileExtension: "cs",
                defaultLocationInProject: "",
                className: $"{Project.ApplicationName()}DbContextConfiguration".Replace(".", string.Empty),
                @namespace: "${Project.Name}"
                );
        }

        public string GetDbContextClassName()
        {
            if (_dbContextName != null)
            {
                return _dbContextName;
            }

            var dbContextTemplate = Project.FindTemplateInstance(DbContextTemplate.Identifier);
            if (dbContextTemplate != null)
            {
                return _dbContextName = dbContextTemplate.GetMetaData().FileName;
            }

            _log.Warning($"{Identifier} - Could not find template with creates DbContext's name, default used instead.");

            return _dbContextName = "DbContext";
        }

        public string GetDbContextNamespace()
        {
            var template = $"{Environment.NewLine}using {{0}};";

            if (_dbContextNamespace != null)
            {
                return string.Format(template, _dbContextNamespace);
            }

            var dbContextTemplate = Project.FindTemplateInstance(DbContextTemplate.Identifier);
            if (dbContextTemplate != null)
            {
                return _dbContextNamespace = string.Format(template, Project.FindTemplateInstance<IHasClassDetails>(DbContextTemplate.Identifier).Namespace);
            }

            _log.Warning($"{Identifier} - Could not find template with creates DbContext's name, default used instead.");

            return _dbContextNamespace = string.Format(template, "System.Data.Entity");
        }

        public string Seeds()
        {
            var seeds = GetDecorators().SelectMany(x => x.Seed(DbContextVariableName)).ToArray();
            if (!seeds.Any())
            {
                return string.Empty;
            }

            const string tabbing = "            ";
            return $"{Environment.NewLine}" +
               seeds
                .Select(x => x.Trim())
                .Select(x => x.StartsWith("#") ? x : $"{tabbing}{x}")
                .Aggregate((x, y) => $"{x}{Environment.NewLine}" +
                                     $"{y}");
        }

        public string Methods()
        {
            var methods = GetDecorators().SelectMany(x => x.Methods()).ToArray();
            if (!methods.Any())
            {
                return string.Empty;
            }

            const string tabbing = "        ";
            return $"{Environment.NewLine}" +
                   $"{Environment.NewLine}" +
                   methods
                    .Select(x => x.Trim())
                    .Select(x => $"{tabbing}{x}")
                    .Aggregate((x, y) => $"{x}{Environment.NewLine}" +
                                         $"{Environment.NewLine}" +
                                         $"{y}");
        }

        public override IEnumerable<INugetPackageInfo> GetNugetDependencies()
        {
            return new[]
            {
                NugetPackages.EntityFramework,
            }
            .Union(base.GetNugetDependencies())
            .ToArray();
        }

        public IEnumerable<ITemplateDependency> GetTemplateDependencies()
        {
            return new[]
            {
                TemplateDependency.OnTemplate(DbContextTemplate.Identifier),
            };
        }

        public override RoslynMergeConfig ConfigureRoslynMerger()
        {
            return new RoslynMergeConfig(new TemplateMetaData(Id, "1.0"));
        }

        public IEnumerable<IMigrationSeedDecorator> GetDecorators()
        {
            return _decorators ?? (_decorators = Project.ResolveDecorators(this));
        }
    }
}
