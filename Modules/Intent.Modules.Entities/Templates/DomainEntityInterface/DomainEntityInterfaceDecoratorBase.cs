﻿using Intent.Templates;
using System.Collections.Generic;
using Intent.Modelers.Domain.Api;
using Intent.Modules.Common.Templates;
using IAttribute = Intent.Metadata.Models.IAttribute;
using IOperation = Intent.Metadata.Models.IOperation;

namespace Intent.Modules.Entities.Templates.DomainEntityInterface
{
    public abstract class DomainEntityInterfaceDecoratorBase : DecoratorBase, ITemplateDecorator, IDeclareUsings, IAttibuteTypeConverter
    {
        protected DomainEntityInterfaceDecoratorBase(DomainEntityInterfaceTemplate template)
        {
            Template = template;
        }

        public DomainEntityInterfaceTemplate Template { get; private set; }

        public virtual IEnumerable<string> DeclareUsings() { return new List<string>(); }

        public virtual IEnumerable<string> GetInterfaces(ClassModel @class) { return new List<string>(); }

        public virtual string InterfaceAnnotations(ClassModel @class) { return null; }

        public virtual string BeforeProperties(ClassModel @class) { return null; }

        public virtual string PropertyBefore(IAttribute attribute) { return null; }

        public virtual string PropertyAnnotations(IAttribute attribute) { return null; }

        public virtual string PropertyBefore(IAssociationEnd associationEnd) { return null; }

        public virtual string PropertyAnnotations(IAssociationEnd associationEnd) { return null; }

        public virtual string AttributeAccessors(IAttribute attribute) { return null; }

        public virtual string AssociationAccessors(IAssociationEnd associationEnd) { return null; }

        public virtual string ConvertAttributeType(IAttribute attribute) { return null; }

        public virtual bool CanWriteDefaultAttribute(IAttribute attribute) { return true; }
        public virtual bool CanWriteDefaultAssociation(IAssociationEnd association) { return true; }
        public virtual bool CanWriteDefaultOperation(IOperation operation) { return true; }
    }
}