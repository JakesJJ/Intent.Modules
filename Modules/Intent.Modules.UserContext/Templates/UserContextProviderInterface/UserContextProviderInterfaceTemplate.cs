﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.UserContext.Templates.UserContextProviderInterface
{
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
    
    #line 1 "C:\Dev\Intent.Modules\Modules\Intent.Modules.UserContext\Templates\UserContextProviderInterface\UserContextProviderInterfaceTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class UserContextProviderInterfaceTemplate : IntentRoslynProjectItemTemplateBase<object>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(" \r\n");
            
            #line 13 "C:\Dev\Intent.Modules\Modules\Intent.Modules.UserContext\Templates\UserContextProviderInterface\UserContextProviderInterfaceTemplate.tt"




            
            #line default
            #line hidden
            this.Write("using Intent.Framework.Core.Context;\r\nusing System;\r\nusing System.Collections.Gen" +
                    "eric;\r\nusing System.Linq;\r\nusing System.Security.Claims;\r\n");
            
            #line 22 "C:\Dev\Intent.Modules\Modules\Intent.Modules.UserContext\Templates\UserContextProviderInterface\UserContextProviderInterfaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DependencyUsings));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 26 "C:\Dev\Intent.Modules\Modules\Intent.Modules.UserContext\Templates\UserContextProviderInterface\UserContextProviderInterfaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public interface IUserContextProvider<T>\r\n    {\r\n        T GetUserContex" +
                    "t();\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
