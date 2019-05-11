﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.Electron.NodeEdgeProxy.Templates.NodeEdgeCsharpReceivingProxy
{
    using Intent.Modules.Common.Templates;
    using Intent.Modelers.Services.Api;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\NodeEdgeCsharpReceivingProxy\NodeEdgeCsharpReceivingProxyTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class NodeEdgeCsharpReceivingProxyTemplate : IntentRoslynProjectItemTemplateBase<IServiceModel>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing Syste" +
                    "m.Threading.Tasks;\r\nusing Newtonsoft.Json;\r\nusing Newtonsoft.Json.Serialization;" +
                    "\r\nusing Unity;\r\n");
            
            #line 13 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\NodeEdgeCsharpReceivingProxy\NodeEdgeCsharpReceivingProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DependencyUsings));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 17 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\NodeEdgeCsharpReceivingProxy\NodeEdgeCsharpReceivingProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public class ");
            
            #line 19 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\NodeEdgeCsharpReceivingProxy\NodeEdgeCsharpReceivingProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write("NodeEdgeProxy : IInvokable\r\n    {\r\n        private readonly I");
            
            #line 21 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\NodeEdgeCsharpReceivingProxy\NodeEdgeCsharpReceivingProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write(" _appService;\r\n        private readonly JsonSerializerSettings _jsonSerializerSet" +
                    "tings;\r\n\r\n        public ");
            
            #line 24 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\NodeEdgeCsharpReceivingProxy\NodeEdgeCsharpReceivingProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write("NodeEdgeProxy()\r\n        {\r\n            _appService = UnityConfig.GetConfiguredCo" +
                    "ntainer().Resolve<I");
            
            #line 26 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\NodeEdgeCsharpReceivingProxy\NodeEdgeCsharpReceivingProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write(@">();
            _jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        public async Task<object> Invoke(dynamic input)
        {
            return await Task.Factory.StartNew<object>(() =>
            {
                try
                {
                    var methodName = (string)input.methodName;
                    var methodParameters = ((object[]) input.methodParameters).Select(x => (string) x).ToArray();
                    AsyncAwaitOperationContext.SetHeaders(((IEnumerable<dynamic>)input.headers).ToDictionary(x => (string)x.name, x => (string)x.value));

                    switch (methodName)
                    {
");
            
            #line 45 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\NodeEdgeCsharpReceivingProxy\NodeEdgeCsharpReceivingProxyTemplate.tt"

                        // An exception gets thrown if "null" is returned, so we always wrap everthing up in an object and 
                        // then on the receiving side we always read the "response" property as necessary. 
                        foreach(var operation in Model.Operations)
                        {

            
            #line default
            #line hidden
            this.Write("                        case nameof(");
            
            #line 51 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\NodeEdgeCsharpReceivingProxy\NodeEdgeCsharpReceivingProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(operation.Name));
            
            #line default
            #line hidden
            this.Write("):\r\n                            return JsonConvert.SerializeObject(new\r\n         " +
                    "                   {\r\n                                Response = ");
            
            #line 54 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\NodeEdgeCsharpReceivingProxy\NodeEdgeCsharpReceivingProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(operation.Name));
            
            #line default
            #line hidden
            this.Write("(methodParameters)\r\n                            }, _jsonSerializerSettings);\r\n");
            
            #line 56 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\NodeEdgeCsharpReceivingProxy\NodeEdgeCsharpReceivingProxyTemplate.tt"

                        } // foreach(var operation in Model.Operations)

            
            #line default
            #line hidden
            this.Write("                        default:\r\n                            throw new Exception" +
                    "($\"Unknown method: {methodName}\");\r\n                    }\r\n                }\r\n  " +
                    "              catch (Exception e)\r\n                {");
            
            #line 64 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\NodeEdgeCsharpReceivingProxy\NodeEdgeCsharpReceivingProxyTemplate.tt"
 
                    // Sometimes Edge falls over with a StackOverflow exception when it tries 
                    // to send some exceptions back to the client, so we just wrap all exceptions
                    // just in case.

                    // For example, new System.IO.FileSystemWatcher("invalid path", filterCriteria);
                
            
            #line default
            #line hidden
            this.Write("                    throw new SerializableException(e);\r\n                }\r\n     " +
                    "       }, TaskCreationOptions.LongRunning);\r\n        }\r\n");
            
            #line 75 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\NodeEdgeCsharpReceivingProxy\NodeEdgeCsharpReceivingProxyTemplate.tt"

        foreach(var operation in Model.Operations)
        {

            
            #line default
            #line hidden
            this.Write("\r\n        private object ");
            
            #line 80 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\NodeEdgeCsharpReceivingProxy\NodeEdgeCsharpReceivingProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(operation.Name));
            
            #line default
            #line hidden
            this.Write("(string[] methodParameters)\r\n        {\r\n");
            
            #line 82 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\NodeEdgeCsharpReceivingProxy\NodeEdgeCsharpReceivingProxyTemplate.tt"

            if (operation.ReturnType != null)
            {

            
            #line default
            #line hidden
            this.Write("            return _appService.");
            
            #line 86 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\NodeEdgeCsharpReceivingProxy\NodeEdgeCsharpReceivingProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(operation.Name));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 86 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\NodeEdgeCsharpReceivingProxy\NodeEdgeCsharpReceivingProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetOperationCallParameters(operation)));
            
            #line default
            #line hidden
            this.Write(");\r\n");
            
            #line 87 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\NodeEdgeCsharpReceivingProxy\NodeEdgeCsharpReceivingProxyTemplate.tt"

            }
            else
            {

            
            #line default
            #line hidden
            this.Write("            _appService.");
            
            #line 92 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\NodeEdgeCsharpReceivingProxy\NodeEdgeCsharpReceivingProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(operation.Name));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 92 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\NodeEdgeCsharpReceivingProxy\NodeEdgeCsharpReceivingProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetOperationCallParameters(operation)));
            
            #line default
            #line hidden
            this.Write(");\r\n            return null;\r\n");
            
            #line 94 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\NodeEdgeCsharpReceivingProxy\NodeEdgeCsharpReceivingProxyTemplate.tt"

            }

            
            #line default
            #line hidden
            this.Write("        }\r\n");
            
            #line 98 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\NodeEdgeCsharpReceivingProxy\NodeEdgeCsharpReceivingProxyTemplate.tt"

        }

            
            #line default
            #line hidden
            this.Write("\r\n        private T Deserialize<T>(string serializedString)\r\n        {\r\n         " +
                    "   return serializedString != null\r\n                ? JsonConvert.DeserializeObj" +
                    "ect<T>(serializedString)\r\n                : default(T);\r\n        }\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
