using System.Collections.Generic;
using System.Linq;
using Zu.TypeScript;
using Zu.TypeScript.Change;
using Zu.TypeScript.TsTypes;

namespace Intent.Modules.Angular.Editor
{
    public class TypescriptFileEditor
    {
        private string _source;

        public TypescriptFileEditor(string source)
        {
            _source = source;
        }

        public void AddImportIfNotExists(string className, string location)
        {
            var ast = new TypeScriptAST(_source);
            var change = new ChangeAST();
            var imports = ast.OfKind(SyntaxKind.ImportDeclaration);

            if (imports.Any())
            {
                if (imports.All(x => x.GetDescendants(false).OfKind(SyntaxKind.Identifier).FirstOrDefault()?.IdentifierStr != className))
                {
                    change.InsertAfter(imports.Last(), $@"
import {{ {className} }} from '{location}';");
                }
            }
            else
            {
                change.InsertBefore(ast.RootNode, $@"
import {{ {className} }} from '{location}';");
            }
            _source = change.GetChangedSource(_source);
        }

        public IList<TypescriptClass> Classes()
        {
            var ast = new TypeScriptAST(_source);
            return ast.OfKind(SyntaxKind.ClassDeclaration).Select(x => new TypescriptClass(x, this)).ToList();
        }

        public string GetSource()
        {
            return _source;
        }

        public void UpdateChanges(ChangeAST change)
        {
            _source = change.GetChangedSource(_source);
        }
    }
}