using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.ModuleBuilder.Api;
using Intent.Modules.Common;
using Intent.Modules.Common.Templates;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.ProjectItemTemplate.Partial", Version = "1.0")]

namespace Intent.Modules.ModuleBuilder.Templates.StaticContentOutputReadme
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    partial class StaticContentOutputReadmeTemplate : IntentTemplateBase<StaticContentTemplateModel>
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Intent.ModuleBuilder.Templates.StaticContentOutputReadme";

        [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
        public StaticContentOutputReadmeTemplate(IOutputTarget outputTarget, StaticContentTemplateModel model) : base(TemplateId, outputTarget, model)
        {
        }

        public override ITemplateFileConfig GetTemplateFileConfig()
        {
            return new TemplateFileConfig(
                fileName: "readme",
                fileExtension: "txt",
                relativeLocation: GetContentFolderLocation(Model)
            );
        }

        public static string GetContentFolderLocation(StaticContentTemplateModel model)
        {
            var path = "content";
            if (!string.IsNullOrWhiteSpace(model.GetTemplateSettings().ContentSubfolder()))
            {
                path += "/" + model.GetTemplateSettings().ContentSubfolder();
            }
            return path;
        }
    }
}