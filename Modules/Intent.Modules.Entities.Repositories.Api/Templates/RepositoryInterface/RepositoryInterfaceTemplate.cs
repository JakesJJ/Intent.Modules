﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.Entities.Repositories.Api.Templates.RepositoryInterface
{
    using Intent.Modelers.Domain.Api;
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
    
    #line 1 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities.Repositories.Api\Templates\RepositoryInterface\RepositoryInterfaceTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class RepositoryInterfaceTemplate : IntentRoslynProjectItemTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing Syste" +
                    "m.Linq.Expressions;\r\nusing System.Threading;\r\nusing System.Threading.Tasks;\r\n\r\n[" +
                    "assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 22 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities.Repositories.Api\Templates\RepositoryInterface\RepositoryInterfaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public interface ");
            
            #line 24 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities.Repositories.Api\Templates\RepositoryInterface\RepositoryInterfaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(@"<TDomain, TPersistence>
    {
        void Add(TDomain entity);
        void Remove(TDomain entity);
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<TDomain> FindAsync(Expression<Func<TPersistence, bool>> filterExpression);
        Task<List<TDomain>> FindAllAsync();
        Task<List<TDomain>> FindAllAsync(Expression<Func<TPersistence, bool>> filterExpression);
        Task<List<TDomain>> FindAllAsync(Expression<Func<TPersistence, bool>> filterExpression, Func<IQueryable<TPersistence>, IQueryable<TPersistence>> linq);
        Task<IPagedResult<TDomain>> FindAllAsync(int pageNo, int pageSize);
        Task<IPagedResult<TDomain>> FindAllAsync(Expression<Func<TPersistence, bool>> filterExpression, int pageNo, int pageSize);
        Task<IPagedResult<TDomain>> FindAllAsync(Expression<Func<TPersistence, bool>> filterExpression, int pageIndex, int pageSize, Func<IQueryable<TPersistence>, IQueryable<TPersistence>> linq);
        Task<int> CountAsync(Expression<Func<TPersistence, bool>> filterExpression);
        Task<bool> AnyAsync(Expression<Func<TPersistence, bool>> filterExpression);
    }
}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
