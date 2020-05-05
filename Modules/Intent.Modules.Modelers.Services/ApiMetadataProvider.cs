using System.Collections.Generic;
using System.Linq;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.Modelers.Services.Api;
using Intent.RoslynWeaver.Attributes;

[assembly: IntentTemplate("ModuleBuilder.Templates.Api.ApiMetadataProvider", Version = "1.0")]
[assembly: DefaultIntentManaged(Mode.Fully)]

namespace Intent.Modules.Modelers.Services
{
    public class ApiMetadataProvider
    {
        private readonly IMetadataManager _metadataManager;

        public ApiMetadataProvider(IMetadataManager metadataManager)
        {
            _metadataManager = metadataManager;
        }

        public IList<DTOModel> GetDTOModels(IApplication application)
        {
            var models = _metadataManager.GetMetadata<IElement>("Services", application.Id)
                .Where(x => x.SpecializationType == DTOModel.SpecializationType)
                .Select(x => new DTOModel(x))
                .ToList<DTOModel>();
            return models;
        }

        public IList<EnumModel> GetEnumModels(IApplication application)
        {
            var models = _metadataManager.GetMetadata<IElement>("Services", application.Id)
                .Where(x => x.SpecializationType == EnumModel.SpecializationType)
                .Select(x => new EnumModel(x))
                .ToList<EnumModel>();
            return models;
        }

        public IList<FolderModel> GetFolderModels(IApplication application)
        {
            var models = _metadataManager.GetMetadata<IElement>("Services", application.Id)
                .Where(x => x.SpecializationType == FolderModel.SpecializationType)
                .Select(x => new FolderModel(x))
                .ToList<FolderModel>();
            return models;
        }

        public IList<ServiceModel> GetServiceModels(IApplication application)
        {
            var models = _metadataManager.GetMetadata<IElement>("Services", application.Id)
                .Where(x => x.SpecializationType == ServiceModel.SpecializationType)
                .Select(x => new ServiceModel(x))
                .ToList<ServiceModel>();
            return models;
        }

        public IList<TypeDefinitionModel> GetTypeDefinitionModels(IApplication application)
        {
            var models = _metadataManager.GetMetadata<IElement>("Services", application.Id)
                .Where(x => x.SpecializationType == TypeDefinitionModel.SpecializationType)
                .Select(x => new TypeDefinitionModel(x))
                .ToList<TypeDefinitionModel>();
            return models;
        }

    }
}