using System.Collections.Generic;
using System.Linq;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.ModuleBuilder.Api;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.Api.ApiMetadataProviderExtensions", Version = "1.0")]

namespace Intent.ModuleBuilder.Api
{
    public static class ApiMetadataProviderExtensions
    {
        public static IList<AssociationSettingsModel> GetAssociationSettingsModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(AssociationSettingsModel.SpecializationTypeId)
                .Select(x => new AssociationSettingsModel(x))
                .ToList();
        }

        public static IList<CoreTypeModel> GetCoreTypeModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(CoreTypeModel.SpecializationTypeId)
                .Select(x => new CoreTypeModel(x))
                .ToList();
        }

        public static IList<DesignerModel> GetDesignerModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(DesignerModel.SpecializationTypeId)
                .Select(x => new DesignerModel(x))
                .ToList();
        }

        public static IList<DesignerExtensionModel> GetDesignerExtensionModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(DesignerExtensionModel.SpecializationTypeId)
                .Select(x => new DesignerExtensionModel(x))
                .ToList();
        }

        public static IList<DesignerSettingsModel> GetDesignerSettingsModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(DesignerSettingsModel.SpecializationTypeId)
                .Select(x => new DesignerSettingsModel(x))
                .ToList();
        }

        public static IList<DesignersFolderModel> GetDesignersFolderModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(DesignersFolderModel.SpecializationTypeId)
                .Select(x => new DesignersFolderModel(x))
                .ToList();
        }

        public static IList<DiagramSettingsModel> GetDiagramSettingsModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(DiagramSettingsModel.SpecializationTypeId)
                .Select(x => new DiagramSettingsModel(x))
                .ToList();
        }

        public static IList<ElementExtensionModel> GetElementExtensionModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(ElementExtensionModel.SpecializationTypeId)
                .Select(x => new ElementExtensionModel(x))
                .ToList();
        }

        public static IList<ElementSettingsModel> GetElementSettingsModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(ElementSettingsModel.SpecializationTypeId)
                .Select(x => new ElementSettingsModel(x))
                .ToList();
        }

        public static IList<FactoryExtensionModel> GetFactoryExtensionModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(FactoryExtensionModel.SpecializationTypeId)
                .Select(x => new FactoryExtensionModel(x))
                .ToList();
        }

        public static IList<FileTemplateModel> GetFileTemplateModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(FileTemplateModel.SpecializationTypeId)
                .Select(x => new FileTemplateModel(x))
                .ToList();
        }

        public static IList<ModuleSettingsConfigurationModel> GetModuleSettingsConfigurationModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(ModuleSettingsConfigurationModel.SpecializationTypeId)
                .Select(x => new ModuleSettingsConfigurationModel(x))
                .ToList();
        }

        public static IList<PackageExtensionModel> GetPackageExtensionModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(PackageExtensionModel.SpecializationTypeId)
                .Select(x => new PackageExtensionModel(x))
                .ToList();
        }

        public static IList<PackageSettingsModel> GetPackageSettingsModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(PackageSettingsModel.SpecializationTypeId)
                .Select(x => new PackageSettingsModel(x))
                .ToList();
        }

        public static IList<ScriptModel> GetScriptModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(ScriptModel.SpecializationTypeId)
                .Select(x => new ScriptModel(x))
                .ToList();
        }

        public static IList<TemplateDecoratorModel> GetTemplateDecoratorModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(TemplateDecoratorModel.SpecializationTypeId)
                .Select(x => new TemplateDecoratorModel(x))
                .ToList();
        }

        public static IList<TemplateDecoratorContractModel> GetTemplateDecoratorContractModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(TemplateDecoratorContractModel.SpecializationTypeId)
                .Select(x => new TemplateDecoratorContractModel(x))
                .ToList();
        }

        public static IList<TemplateRegistrationModel> GetTemplateRegistrationModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(TemplateRegistrationModel.SpecializationTypeId)
                .Select(x => new TemplateRegistrationModel(x))
                .ToList();
        }

    }
}