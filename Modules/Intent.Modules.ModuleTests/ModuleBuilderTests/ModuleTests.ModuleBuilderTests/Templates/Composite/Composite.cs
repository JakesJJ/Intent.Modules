// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace ModuleTests.ModuleBuilderTests.Templates.Composite
{
    using System.Collections.Generic;
    using System.Linq;
    using Intent.Modules.Common;
    using Intent.Modules.Common.Templates;
    using Intent.Metadata.Models;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleTests\ModuleBuilderTests\ModuleTests.ModuleBuilderTests\Templates\Composite\Composite.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class Composite : IntentRoslynProjectItemTemplateBase<IClass>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\nusing System;\r\n");
            
            #line 10 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleTests\ModuleBuilderTests\ModuleTests.ModuleBuilderTests\Templates\Composite\Composite.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DependencyUsings));
            
            #line default
            #line hidden
            this.Write(@"
// Mode.Fully will overwrite file on each run. 
// Add in explicit [IntentManaged.Ignore] attributes to class or methods. Alternatively change to Mode.Merge (additive) or Mode.Ignore (once-off)
[assembly: DefaultIntentManaged(Mode.Fully)]

namespace ");
            
            #line 15 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleTests\ModuleBuilderTests\ModuleTests.ModuleBuilderTests\Templates\Composite\Composite.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public class ");
            
            #line 17 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleTests\ModuleBuilderTests\ModuleTests.ModuleBuilderTests\Templates\Composite\Composite.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("\r\n    {\r\n        public ");
            
            #line 19 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleTests\ModuleBuilderTests\ModuleTests.ModuleBuilderTests\Templates\Composite\Composite.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetDependantATemplateFullName()));
            
            #line default
            #line hidden
            this.Write(" DependantA { get; }\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
