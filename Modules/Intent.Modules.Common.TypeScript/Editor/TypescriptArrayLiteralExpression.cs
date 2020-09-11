using System.Collections.Generic;
using System.Linq;
using Zu.TypeScript.TsTypes;

namespace Intent.Modules.Common.TypeScript.Editor
{
    public class TypeScriptArrayLiteralExpression : TypeScriptNode
    {
        private readonly TypeScriptNode _parent;

        public TypeScriptArrayLiteralExpression(Node node, TypeScriptNode parent) : base(node, parent.Editor)
        {
            _parent = parent;
        }

        public override string GetIdentifier(Node node)
        {
            return node.Parent.Children.IndexOf(node).ToString();
        }

        public override bool IsMerged()
        {
            return _parent.IsMerged();
        }

        public override void UpdateNode(Node node)
        {
            base.UpdateNode(node);
            var index = 0;
            foreach (var child in node.Children)
            {
                switch (child.Kind)
                {
                    case SyntaxKind.ObjectLiteralExpression:
                        this.InsertOrUpdateChildNode(child, index, () => new TypeScriptObjectLiteralExpression(child, this));
                        index++;
                        continue;
                    case SyntaxKind.ArrayLiteralExpression:
                        this.InsertOrUpdateChildNode(child, index, () => new TypeScriptArrayLiteralExpression(child, this));
                        index++;
                        continue;
                    case SyntaxKind.StringLiteral:
                        this.InsertOrUpdateChildNode(child, index, () => new TypescriptLiteral(child, this));
                        index++;
                        continue;
                    case SyntaxKind.NumericLiteral:
                        this.InsertOrUpdateChildNode(child, index, () => new TypescriptLiteral(child, this));
                        index++;
                        continue;
                    case SyntaxKind.RegularExpressionLiteral:
                        this.InsertOrUpdateChildNode(child, index, () => new TypescriptLiteral(child, this));
                        index++;
                        continue;
                    case SyntaxKind.Identifier:
                        this.InsertOrUpdateChildNode(child, index, () => new TypescriptLiteral(child, this));
                        index++;
                        continue;
                        // OTHERS? Not sure...
                        //case SyntaxKind.TypeLiteral:
                        //    this.InsertOrUpdateNode(node, index, () => new TypescriptLiteral(node, this));
                        //    index++;
                        //    continue;
                }
            }
        }

        public override void MergeWith(TypeScriptNode node)
        {
            base.MergeWith(node);
        }

        public override void InsertBefore(TypeScriptNode existing, TypeScriptNode node)
        {
            Editor.InsertBefore(existing, $"{node.GetTextWithComments()},");
        }

        public override void InsertAfter(TypeScriptNode existing, TypeScriptNode node)
        {
            Editor.InsertAfter(existing, $",{node.GetTextWithComments()}");
        }


        public List<T> GetValues<T>()
                where T : TypeScriptNode
        {
            return Node.Children.Select<Node, TypeScriptNode>(x =>
           {
               switch (x.Kind)
               {
                   case SyntaxKind.ObjectLiteralExpression:
                       return new TypeScriptObjectLiteralExpression(x, this);
                   case SyntaxKind.ArrayLiteralExpression:
                       return new TypeScriptArrayLiteralExpression(x, this);
                   case SyntaxKind.FirstLiteralToken:
                   case SyntaxKind.StringLiteral:
                       return new TypescriptLiteral(x, this);
                   default:
                       return null;
               }
           }).Select(x => x as T).ToList();
        }

        public void AddValue(string literal)
        {
            if (!Node.Children.Any())
            {
                Editor.Change.ChangeNode(Node, $@"[
  {literal}
]");
            }
            else
            {
                Editor.Change.InsertAfter(Node.Children.Last(), $@",
  {literal}");
            }
            Editor.UpdateNodes();
        }

        public override bool IsIgnored() => false;
    }
}