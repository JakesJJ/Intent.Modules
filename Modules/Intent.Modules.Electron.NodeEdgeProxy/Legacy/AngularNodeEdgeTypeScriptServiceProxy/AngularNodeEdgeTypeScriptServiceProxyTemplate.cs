﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 14.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.Electron.NodeEdgeProxy.Legacy.AngularNodeEdgeTypeScriptServiceProxy
{
    using Intent.SoftwareFactory.MetaModels.Class;
    using Intent.SoftwareFactory.MetaModels.Service;
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
    
    #line 1 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class AngularNodeEdgeTypeScriptServiceProxyTemplate : IntentProjectItemTemplateBase<ServiceModel>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(" \r\n\r\nnamespace ");
            
            #line 15 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write(" {\r\n\r\n    export class ");
            
            #line 17 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write(@"Proxy {
        private edgeProxy: IEdgeProxy;

        static $inject = [""$q"", ""Config"", ""Edge""];
        constructor(
            private $q: ng.IQService,
            public config: any,
            edge: IEdge) {

            try {
                this.edgeProxy = edge.func({
                    assemblyFile: this.config[""edge_assembly_path""] + """);
            
            #line 28 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AssemblyName));
            
            #line default
            #line hidden
            this.Write(".dll\",\r\n                    typeName: \"");
            
            #line 29 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TypeName));
            
            #line default
            #line hidden
            this.Write("\",\r\n                    methodName: \"Invoke\"\r\n                });\r\n            } " +
                    "catch (e) {\r\n                console.error(e)\r\n            }\r\n        }\r\n\r\n");
            
            #line 37 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
        foreach (var o in Model.Operations)
        {

            if (o.HasReturnType())
            {

            
            #line default
            #line hidden
            this.Write("        public ");
            
            #line 43 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(o.Name)));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 43 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
 GetMethodDefinitionParameters(o); 
            
            #line default
            #line hidden
            this.Write("): ng.IPromise<");
            
            #line 43 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
 GetReturnType(o); 
            
            #line default
            #line hidden
            this.Write("> {\r\n            try {\r\n                var data = {\r\n                    operati" +
                    "onName: \"");
            
            #line 46 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(o.Name));
            
            #line default
            #line hidden
            this.Write("\",\r\n                    payload: JSON.stringify({\r\n");
            
            #line 48 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"

                    for (var i=0; i<o.Parameters.Count; i++)
                    {
                        var p = o.Parameters[i];
                        var conditionalComma = i+1 != o.Parameters.Count ? "," : "";
                        

            
            #line default
            #line hidden
            this.Write("                        ");
            
            #line 55 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(p.Name));
            
            #line default
            #line hidden
            this.Write(": ");
            
            #line 55 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(p.Name));
            
            #line default
            #line hidden
            
            #line 55 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(conditionalComma));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 56 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"

                    }

            
            #line default
            #line hidden
            this.Write("                    })\r\n                };\r\n\r\n                return this.$q((res" +
                    "olve: (data: ");
            
            #line 62 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
 GetReturnType(o); 
            
            #line default
            #line hidden
            this.Write(@") => void, reject: (reason: any) => void) => {
                    this.edgeProxy(data, (error, result: string) => {
                        if (error) {
                            reject(error);
                            return;
                        }

                        resolve(JSON.parse(result).response);
                    });
                });
            } catch (e) {
                console.error(e);
                return this.$q.reject(e);
            }
        }

");
            
            #line 78 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"

            }
            else
            {

            
            #line default
            #line hidden
            this.Write("        public ");
            
            #line 83 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(o.Name)));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 83 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
 GetMethodDefinitionParameters(o); 
            
            #line default
            #line hidden
            this.Write("): ng.IPromise<void> {\r\n            try {\r\n                var data = {\r\n        " +
                    "            operationName: \"");
            
            #line 86 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(o.Name));
            
            #line default
            #line hidden
            this.Write("\",\r\n                    payload: JSON.stringify({\r\n");
            
            #line 88 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"

                    for (var i=0; i<o.Parameters.Count; i++)
                    {
                        var p = o.Parameters[i];
                        var conditionalComma = i+1 != o.Parameters.Count ? "," : "";
                        

            
            #line default
            #line hidden
            this.Write("                        ");
            
            #line 95 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(p.Name));
            
            #line default
            #line hidden
            this.Write(": ");
            
            #line 95 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(p.Name));
            
            #line default
            #line hidden
            
            #line 95 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(conditionalComma));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 96 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"

                    }

            
            #line default
            #line hidden
            this.Write(@"                    })
                };

                return this.$q((resolve: (data: any) => void, reject: (reason: any) => void) => {
                    this.edgeProxy(data, (error: any) => {
                        if (error) {
                            reject(error);
                            return;
                        }

                        resolve(null);
                    });
                });
            } catch (e) {
                console.error(e);
                return this.$q.reject(e);
            }
        }

");
            
            #line 118 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
            }
        }

            
            #line default
            #line hidden
            this.Write("    }\r\n\r\n    angular.module(\"App\").service(\"");
            
            #line 123 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write("Proxy\", ");
            
            #line 123 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write("Proxy);\r\n}\r\n\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 126 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"


void GetMethodDefinitionParameters(ServiceOperationModel o) 
{

    for(int i = 0; i < o.Parameters.Count; i++) 
    { 
        ParameterModel p = o.Parameters[i];
        if (p.Type.TypeName.StartsWith("IList") || p.Type.TypeName.StartsWith("List"))
        {
            string modelType = p.Type.GenericArguments[0].FullName;
            
        
        #line default
        #line hidden
        
        #line 137 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture((i != 0) ? ", " : ""));

        
        #line default
        #line hidden
        
        #line 137 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(p.Name)));

        
        #line default
        #line hidden
        
        #line 137 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
this.Write(": ");

        
        #line default
        #line hidden
        
        #line 137 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(ConvertType(modelType)));

        
        #line default
        #line hidden
        
        #line 137 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
this.Write("[]");

        
        #line default
        #line hidden
        
        #line 137 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"

        }
        else
        {
            
        
        #line default
        #line hidden
        
        #line 141 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture((i != 0) ? ", " : ""));

        
        #line default
        #line hidden
        
        #line 141 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(p.Name)));

        
        #line default
        #line hidden
        
        #line 141 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
this.Write(": ");

        
        #line default
        #line hidden
        
        #line 141 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(ConvertType(p.Type.FullName)));

        
        #line default
        #line hidden
        
        #line 141 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"

        }
    }
}

void GetMethodCallParameters(ServiceOperationModel o) 
{

    for(int i = 0; i < o.Parameters.Count; i++) 
    { 
        ParameterModel p = o.Parameters[i];
        if (i != 0)
        {
            
        
        #line default
        #line hidden
        
        #line 154 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
this.Write(", ");

        
        #line default
        #line hidden
        
        #line 154 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"

        }
    
        
        #line default
        #line hidden
        
        #line 156 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(p.Name)));

        
        #line default
        #line hidden
        
        #line 156 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
this.Write(": ");

        
        #line default
        #line hidden
        
        #line 156 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(LowerFirst(p.Name)));

        
        #line default
        #line hidden
        
        #line 156 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"

    }
    
}

void GetReturnType(ServiceOperationModel o)
{
    if (o.ReturnType.TypeName.StartsWith("PagedResult"))
    {
        string modelType = o.ReturnType.GenericArguments[0].FullName;
        
        
        #line default
        #line hidden
        
        #line 166 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
this.Write("Contracts.PagedResultDTO<");

        
        #line default
        #line hidden
        
        #line 166 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(ConvertType(modelType)));

        
        #line default
        #line hidden
        
        #line 166 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
this.Write(">");

        
        #line default
        #line hidden
        
        #line 166 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"

    }
    else if (o.ReturnType.TypeName.StartsWith("IList") || o.ReturnType.TypeName.StartsWith("List"))
    {
        string modelType = o.ReturnType.GenericArguments[0].FullName;
        
        
        #line default
        #line hidden
        
        #line 171 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(ConvertType(modelType)));

        
        #line default
        #line hidden
        
        #line 171 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
this.Write("[]");

        
        #line default
        #line hidden
        
        #line 171 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"

    }
    else
    {
        
        
        #line default
        #line hidden
        
        #line 175 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(ConvertType(o.ReturnType.FullName)));

        
        #line default
        #line hidden
        
        #line 175 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.Electron.NodeEdgeProxy\Legacy\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"

    }
}

string ConvertType(string propertyType)
{
    switch (propertyType)
    {
        case "byte[]":
        case "Byte[]":
        case "System.Byte[]":
            propertyType = "Array<number>";
            break;
        case "DateTime":
        case "DateTime?":
        case "System.DateTime":
        case "System.DateTime?":
        case "System.Nullable<System.DateTime>":
            propertyType = "Date";
            break;
        case "string":
        case "String":
        case "System.String":
        case "Guid":
        case "Guid?":
        case "System.Guid":
        case "System.Guid?":
        case "System.Nullable<System.Guid>":
            propertyType = "string";
            break;
        case "int":
        case "Int32":
        case "Int32?":
        case "System.Int32":
        case "System.Int32?":
        case "System.Nullable<System.Int32>":
        case "decimal":
        case "Decimal":
        case "Decimal?":
        case "System.Decimal":
        case "System.Decimal?":
        case "System.Nullable<System.Decimal>":
        case "System.TimeSpan":
        case "System.TimeSpan?":
        case "System.Nullable<System.TimeSpan>":
            propertyType = "number";
            break;
        case "bool":
        case "Boolean":
        case "System.Boolean":
            propertyType = "boolean";
            break;
        default:
            {
                if (propertyType.IndexOf("Contracts") != -1)
                {
                    propertyType = propertyType.Substring(propertyType.IndexOf("Contracts"));
                }
                else
                {
                    propertyType = "Contracts." + propertyType.Split('.')[propertyType.Split('.').Length - 1];
                }

                break;
            }
    }

    return propertyType;
}

    string LowerFirst(string s)
    {
        if(string.IsNullOrEmpty(s))
            return s;
        return char.ToLowerInvariant(s[0]) + s.Substring(1);
    }

        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
}