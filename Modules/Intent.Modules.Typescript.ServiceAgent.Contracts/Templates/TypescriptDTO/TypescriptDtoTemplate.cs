﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.Typescript.ServiceAgent.Contracts.Templates.TypescriptDTO
{
    using Intent.Modelers.Services.Api;
    using Intent.Modules.Common.Templates;
    using System;
    using System.IO;
    using System.Diagnostics;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Typescript.ServiceAgent.Contracts\Templates\TypescriptDTO\TypescriptDtoTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class TypescriptDtoTemplate : IntentTypescriptProjectItemTemplateBase<IDTOModel>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\nnamespace ");
            
            #line 15 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Typescript.ServiceAgent.Contracts\Templates\TypescriptDTO\TypescriptDtoTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n");
            
            #line 17 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Typescript.ServiceAgent.Contracts\Templates\TypescriptDTO\TypescriptDtoTemplate.tt"
 AddClass(Model);
            
            #line default
            #line hidden
            this.Write("} \r\n\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 20 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Typescript.ServiceAgent.Contracts\Templates\TypescriptDTO\TypescriptDtoTemplate.tt"

    void AddClass(IDTOModel model)
    {

        
        #line default
        #line hidden
        
        #line 23 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Typescript.ServiceAgent.Contracts\Templates\TypescriptDTO\TypescriptDtoTemplate.tt"
this.Write("    export interface ");

        
        #line default
        #line hidden
        
        #line 24 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Typescript.ServiceAgent.Contracts\Templates\TypescriptDTO\TypescriptDtoTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));

        
        #line default
        #line hidden
        
        #line 24 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Typescript.ServiceAgent.Contracts\Templates\TypescriptDTO\TypescriptDtoTemplate.tt"
this.Write("\r\n    {\r\n");

        
        #line default
        #line hidden
        
        #line 26 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Typescript.ServiceAgent.Contracts\Templates\TypescriptDTO\TypescriptDtoTemplate.tt"
 foreach (var field in Model.Fields) {
        
        #line default
        #line hidden
        
        #line 26 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Typescript.ServiceAgent.Contracts\Templates\TypescriptDTO\TypescriptDtoTemplate.tt"
this.Write("        ");

        
        #line default
        #line hidden
        
        #line 27 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Typescript.ServiceAgent.Contracts\Templates\TypescriptDTO\TypescriptDtoTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(field.Name.ToCamelCase()));

        
        #line default
        #line hidden
        
        #line 27 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Typescript.ServiceAgent.Contracts\Templates\TypescriptDTO\TypescriptDtoTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(field.Type.IsNullable ? "?" : ""));

        
        #line default
        #line hidden
        
        #line 27 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Typescript.ServiceAgent.Contracts\Templates\TypescriptDTO\TypescriptDtoTemplate.tt"
this.Write(": ");

        
        #line default
        #line hidden
        
        #line 27 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Typescript.ServiceAgent.Contracts\Templates\TypescriptDTO\TypescriptDtoTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(this.ConvertType(field.Type)));

        
        #line default
        #line hidden
        
        #line 27 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Typescript.ServiceAgent.Contracts\Templates\TypescriptDTO\TypescriptDtoTemplate.tt"
this.Write(";\r\n");

        
        #line default
        #line hidden
        
        #line 28 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Typescript.ServiceAgent.Contracts\Templates\TypescriptDTO\TypescriptDtoTemplate.tt"
}
        
        #line default
        #line hidden
        
        #line 28 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Typescript.ServiceAgent.Contracts\Templates\TypescriptDTO\TypescriptDtoTemplate.tt"
this.Write("    }\r\n");

        
        #line default
        #line hidden
        
        #line 30 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Typescript.ServiceAgent.Contracts\Templates\TypescriptDTO\TypescriptDtoTemplate.tt"

    }

        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
}
