﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 14.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.Entities.DDD.Templates.EntitySpecification
{
    using Intent.MetaModel.Domain;
    using Intent.SoftwareFactory.Templates;
    using System;
    using System.IO;
    using System.Diagnostics;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\EntitySpecification\EntitySpecificationTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class EntitySpecificationTemplate : IntentRoslynProjectItemTemplateBase<IClass>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 13 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\EntitySpecification\EntitySpecificationTemplate.tt"




            
            #line default
            #line hidden
            this.Write("using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing Inten" +
                    "t.CodeGen;\r\nusing Intent.Framework.Domain.Specification;\r\n");
            
            #line 22 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\EntitySpecification\EntitySpecificationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DependencyUsings));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n[assembly: DefaultIntentManaged(Mode.Ignore)]\r\n\r\nnamespace ");
            
            #line 26 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\EntitySpecification\EntitySpecificationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]\r\n    public class ");
            
            #line 29 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\EntitySpecification\EntitySpecificationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" : ");
            
            #line 29 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\EntitySpecification\EntitySpecificationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(BaseClass));
            
            #line default
            #line hidden
            this.Write("\r\n    {\r\n        [IntentManaged(Mode.Fully)]\r\n        public ");
            
            #line 32 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\EntitySpecification\EntitySpecificationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.ParentClass != null ? "new " : ""));
            
            #line default
            #line hidden
            this.Write("static ");
            
            #line 32 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\EntitySpecification\EntitySpecificationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" Where()\r\n        {\r\n            return new ");
            
            #line 34 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\EntitySpecification\EntitySpecificationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("();\r\n        }\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
