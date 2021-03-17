// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.ModuleBuilder.Templates.Api.ApiAssociationModel
{
    using System.Collections.Generic;
    using System.Linq;
    using Intent.Modules.Common;
    using Intent.Modules.Common.Templates;
    using Intent.Modules.Common.CSharp.Templates;
    using Intent.Templates;
    using Intent.Metadata.Models;
    using Intent.ModuleBuilder.Api;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class ApiAssociationModelTemplate : CSharpTemplateBase<Intent.ModuleBuilder.Api.AssociationSettingsModel>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\nusing System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing Int" +
                    "ent.Metadata.Models;\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespac" +
                    "e ");
            
            #line 19 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]\r\n    public class ");
            
            #line 22 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" : IMetadataModel\r\n    {\r\n        public const string SpecializationType = \"");
            
            #line 24 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write("\";\r\n        protected readonly IAssociation _association;\r\n        protected ");
            
            #line 26 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AssociationSourceEndClassName));
            
            #line default
            #line hidden
            this.Write(" _sourceEnd;\r\n        protected ");
            
            #line 27 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AssociationTargetEndClassName));
            
            #line default
            #line hidden
            this.Write(" _targetEnd;\r\n\r\n        public ");
            
            #line 29 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(@"(IAssociation association, string requiredType = SpecializationType)
        {
            if (!requiredType.Equals(association.SpecializationType, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new Exception($""Cannot create a '{GetType().Name}' from association with specialization type '{association.SpecializationType}'. Must be of type '{SpecializationType}'"");
            }
            _association = association;
        }

        public static ");
            
            #line 38 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" CreateFromEnd(IAssociationEnd associationEnd)\r\n        {\r\n            var associ" +
                    "ation = new ");
            
            #line 40 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("(associationEnd.Association);\r\n            return association;\r\n        }\r\n\r\n    " +
                    "    public string Id => _association.Id;\r\n        \r\n        public ");
            
            #line 46 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AssociationSourceEndClassName));
            
            #line default
            #line hidden
            this.Write(" SourceEnd => _sourceEnd ?? (_sourceEnd = new ");
            
            #line 46 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AssociationSourceEndClassName));
            
            #line default
            #line hidden
            this.Write("(_association.SourceEnd, this));\r\n\r\n        public ");
            
            #line 48 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AssociationTargetEndClassName));
            
            #line default
            #line hidden
            this.Write(" TargetEnd => _targetEnd ?? (_targetEnd = new ");
            
            #line 48 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AssociationTargetEndClassName));
            
            #line default
            #line hidden
            this.Write("(_association.TargetEnd, this));\r\n\r\n        public IAssociation InternalAssociati" +
                    "on => _association;\r\n        \r\n        public override string ToString()\r\n      " +
                    "  {\r\n            return _association.ToString();\r\n        }\r\n\r\n        public bo" +
                    "ol Equals(");
            
            #line 57 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(@" other)
        {
            return Equals(_association, other?._association);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((");
            
            #line 67 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(")obj);\r\n        }\r\n\r\n        public override int GetHashCode()\r\n        {\r\n      " +
                    "      return (_association != null ? _association.GetHashCode() : 0);\r\n        }" +
                    "\r\n    }\r\n\r\n    [IntentManaged(Mode.Fully)]\r\n    public class ");
            
            #line 77 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AssociationSourceEndClassName));
            
            #line default
            #line hidden
            this.Write(" : ");
            
            #line 77 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AssociationEndClassName));
            
            #line default
            #line hidden
            this.Write("\r\n    {\r\n        public ");
            
            #line 79 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AssociationSourceEndClassName));
            
            #line default
            #line hidden
            this.Write("(IAssociationEnd associationEnd, ");
            
            #line 79 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" association) : base(associationEnd, association)\r\n        {\r\n        }\r\n    }\r\n\r" +
                    "\n    [IntentManaged(Mode.Fully)]\r\n    public class ");
            
            #line 85 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AssociationTargetEndClassName));
            
            #line default
            #line hidden
            this.Write(" : ");
            
            #line 85 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AssociationEndClassName));
            
            #line default
            #line hidden
            this.Write("\r\n    {\r\n        public ");
            
            #line 87 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AssociationTargetEndClassName));
            
            #line default
            #line hidden
            this.Write("(IAssociationEnd associationEnd, ");
            
            #line 87 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" association) : base(associationEnd, association)\r\n        {\r\n        }\r\n    }\r\n\r" +
                    "\n    [IntentManaged(Mode.Fully)]\r\n    public class ");
            
            #line 93 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AssociationEndClassName));
            
            #line default
            #line hidden
            this.Write(" : ITypeReference, ICanBeReferencedType, IHasStereotypes\r\n    {\r\n        protecte" +
                    "d readonly IAssociationEnd _associationEnd;\r\n        private readonly ");
            
            #line 96 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" _association;\r\n\r\n        public ");
            
            #line 98 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AssociationEndClassName));
            
            #line default
            #line hidden
            this.Write("(IAssociationEnd associationEnd, ");
            
            #line 98 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(@" association)
        {
            _associationEnd = associationEnd;
            _association = association;
        }

        public string Id => _associationEnd.Id;
        public string SpecializationType => _associationEnd.SpecializationType;
        public string SpecializationTypeId => _associationEnd.SpecializationTypeId;
        public string Name => _associationEnd.Name;
        public ");
            
            #line 108 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(@" Association => _association;
        IAssociationEnd InternalAssociationEnd => _associationEnd;
        IAssociation InternalAssociation => _association.InternalAssociation;
        public bool IsNavigable => _associationEnd.IsNavigable;
        public bool IsNullable => _associationEnd.IsNullable;
        public bool IsCollection => _associationEnd.IsCollection;
        public ICanBeReferencedType Element => _associationEnd.Element;
        public IEnumerable<ITypeReference> GenericTypeParameters => _associationEnd.GenericTypeParameters;
        public ITypeReference TypeReference => this;
        public IPackage Package => Element?.Package;
        public string Comment => _associationEnd.Comment;
        public IEnumerable<IStereotype> Stereotypes => _associationEnd.Stereotypes;

        public ");
            
            #line 121 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AssociationEndClassName));
            
            #line default
            #line hidden
            this.Write(" OtherEnd()\r\n        {\r\n            return this.Equals(_association.SourceEnd) ? " +
                    "(");
            
            #line 123 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AssociationEndClassName));
            
            #line default
            #line hidden
            this.Write(")_association.TargetEnd : (");
            
            #line 123 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AssociationEndClassName));
            
            #line default
            #line hidden
            this.Write(@")_association.SourceEnd;
        }

        public bool IsTargetEnd()
        {
            return _associationEnd.IsTargetEnd();
        }

        public bool IsSourceEnd()
        {
            return _associationEnd.IsSourceEnd();
        }
        
        public override string ToString()
        {
            return _associationEnd.ToString();
        }

        public bool Equals(");
            
            #line 141 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AssociationEndClassName));
            
            #line default
            #line hidden
            this.Write(@" other)
        {
            return Equals(_associationEnd, other._associationEnd);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((");
            
            #line 151 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModel\ApiAssociationModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AssociationEndClassName));
            
            #line default
            #line hidden
            this.Write(")obj);\r\n        }\r\n\r\n        public override int GetHashCode()\r\n        {\r\n      " +
                    "      return (_associationEnd != null ? _associationEnd.GetHashCode() : 0);\r\n   " +
                    "     }\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
