﻿using System.ComponentModel;
using Intent.Engine;
using Intent.Modules.Application.ServiceImplementations.Templates.ServiceImplementation;
using Intent.Modules.Common.Registrations;

namespace Intent.Modules.Convention.ServiceImplementations.Decorators
{
    [Description(ConventionDecorator.Identifier)]
    public class ConventionDecoratorRegistration : DecoratorRegistration<ServiceImplementationDecoratorBase>
    {
        public override string DecoratorId => ConventionDecorator.Identifier;

        private readonly IMetadataManager _metaDataManager;

        public ConventionDecoratorRegistration(IMetadataManager metaDataManager)
        {
            _metaDataManager = metaDataManager;
        }

        public override object CreateDecoratorInstance(IApplication application)
        {
            return new ConventionDecorator(_metaDataManager, application);
        }
    }
}
