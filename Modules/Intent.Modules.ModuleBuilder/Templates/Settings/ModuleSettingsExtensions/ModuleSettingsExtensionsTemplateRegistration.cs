using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.ModuleBuilder.Api;
using Intent.Modules.Common;
using Intent.Modules.Common.Registrations;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.TemplateRegistration.FilePerModel", Version = "1.0")]

namespace Intent.Modules.ModuleBuilder.Templates.Settings.ModuleSettingsExtensions
{
    [IntentManaged(Mode.Merge, Body = Mode.Merge, Signature = Mode.Fully)]
    public class ModuleSettingsExtensionsTemplateRegistration : FilePerModelTemplateRegistration<IntentModuleModel>
    {
        public override string TemplateId => ModuleSettingsExtensionsTemplate.TemplateId;
        private readonly IMetadataManager _metadataManager;

        public ModuleSettingsExtensionsTemplateRegistration(IMetadataManager metadataManager)
        {
            _metadataManager = metadataManager;
        }

        public override ITemplate CreateTemplateInstance(IOutputTarget outputTarget, IntentModuleModel model)
        {
            return new ModuleSettingsExtensionsTemplate(outputTarget, model);
        }

        [IntentManaged(Mode.Merge, Body = Mode.Fully, Signature = Mode.Fully)]
        public override IEnumerable<IntentModuleModel> GetModels(IApplication application)
        {
            return _metadataManager.ModuleBuilder(application).GetIntentModuleModels();
        }
    }
}