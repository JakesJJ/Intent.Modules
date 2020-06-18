﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Humanizer.Inflections;
using Intent.Engine;
using Intent.Modules.Common.VisualStudio;
using Intent.Templates;
using Intent.Utils;

namespace Intent.Modules.Common.Templates
{
    public static class TemplateExtensions
    {
        public static IEnumerable<INugetPackageInfo> GetAllNugetDependencies(this ITemplate template)
        {
            return template.GetAll<IHasNugetDependencies, INugetPackageInfo>((i) => i.GetNugetDependencies());
        }

        public static IEnumerable<IAssemblyReference> GetAllAssemblyDependencies(this ITemplate template)
        {
            return template.GetAll<IHasAssemblyDependencies, IAssemblyReference>((i) => i.GetAssemblyDependencies());
        }

        public static string ToCamelCase(this string s, bool reservedWordEscape)
        {
            var result = s.ToCamelCase();

            if (reservedWordEscape && CSharp.ReservedWords.Contains(result))
            {
                return $"@{result}";
            }
            return result;
        }

        public static string AsClassName(this string s)
        {
            if (s.StartsWith("I") && s.Length >= 2 && char.IsUpper(s[1]))
            {
                s = s.Substring(1);
            }
            return s.Replace(".", "");
        }

        public static string ToPrivateMember(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return s;
            }
            return "_" + ToCamelCase(s, false);
        }

        public static string ToCSharpIdentifier(this string s)
        {
            return string.Concat(s.Split(' ').SelectMany(x => x.Split('-')).Select(x => x.ToPascalCase()))
                .Replace("#", "Sharp")
                .Replace("&", "And")
                .Replace("-", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace(",", "")
                .Replace("[", "")
                .Replace("]", "")
                .Replace("{", "")
                .Replace("}", "")
                .Replace(".", "")
                .Replace("/", "")
                .Replace("\\", "")
                .Replace("?", "")
                .Replace("@", "")
                ;
        }

    }

}