﻿using System;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modules.Common.TypeResolution;

namespace Intent.Modules.Common.Types.TypeResolvers
{
    public class CSharpTypeResolver : TypeResolverBase, ITypeResolver
    {
        public CSharpTypeResolver()
        {
        }

        public override string DefaultCollectionFormat { get; set; } = "IEnumerable<{0}>";

        protected override string ResolveType(ITypeReference typeInfo, string collectionFormat = null)
        {
            var result = typeInfo.Element.Name;
            if (typeInfo.Element.Stereotypes.Any(x => x.Name == "C#"))
            {
                string typeName = typeInfo.Element.GetStereotypeProperty<string>("C#", "Type", typeInfo.Element.Name);
                string @namespace = typeInfo.Element.GetStereotypeProperty<string>("C#", "Namespace");

                result = !string.IsNullOrWhiteSpace(@namespace) ? $"{@namespace}.{typeName}" : typeName;

                if (typeInfo.IsNullable && (typeInfo.Element.SpecializationType.Equals("Enum",StringComparison.InvariantCultureIgnoreCase) || (typeInfo.Element.GetStereotypeProperty("C#", "IsPrimitive", false))))
                {
                    result += "?";
                }
            }
            else
            {
                if (typeInfo.IsNullable && typeInfo.Element.SpecializationType.Equals("Enum", StringComparison.InvariantCultureIgnoreCase))
                {
                    result += "?";
                }
            }

            //if (typeInfo.GenericTypeParameters.Any())
            //{
            //    var genericTypeParameters = typeInfo.GenericTypeParameters
            //        .Select(x => Get(x, collectionFormat))
            //        .Aggregate((x, y) => x + ", " + y);
            //    result += $"<{genericTypeParameters}>";
            //}

            if (typeInfo.IsCollection)
            {
                result = string.Format(collectionFormat ?? DefaultCollectionFormat, result);
            }

            return result;
        }
    }
}
