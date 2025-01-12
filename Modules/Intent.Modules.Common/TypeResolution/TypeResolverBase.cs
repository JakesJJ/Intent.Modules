﻿using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modules.Common.Templates;

namespace Intent.Modules.Common.TypeResolution
{
    public abstract class TypeResolverBase : ITypeResolver
    {
        private const string DEFAULT_CONTEXT = "_default_";
        //private readonly IDictionary<string, List<ITypeSource>> _classTypeSources;
        private readonly IDictionary<string, ITypeResolverContext> _contexts;

        protected TypeResolverBase(ITypeResolverContext defaultContext)
        {
            _contexts = new Dictionary<string, ITypeResolverContext>()
            {
                { DEFAULT_CONTEXT, defaultContext }
            };
        }

        protected abstract ITypeResolverContext CreateContext();

        public virtual string DefaultCollectionFormat
        {
            set => SetDefaultCollectionFormatter(CollectionFormatter.Create(value));
        }

        /// <inheritdoc />
        public ICollectionFormatter DefaultCollectionFormatter => _contexts[DEFAULT_CONTEXT].DefaultCollectionFormatter;

        /// <inheritdoc />
        public INullableFormatter DefaultNullableFormatter => _contexts[DEFAULT_CONTEXT].DefaultNullableFormatter;

        public void SetDefaultCollectionFormatter(ICollectionFormatter formatter)
        {
            _contexts[DEFAULT_CONTEXT].SetCollectionFormatter(formatter);
        }

        public void SetDefaultNullableFormatter(INullableFormatter formatter)
        {
            _contexts[DEFAULT_CONTEXT].SetNullableFormatter(formatter);
        }

        public void AddTypeSource(ITypeSource typeSource)
        {
            AddTypeSource(typeSource, DEFAULT_CONTEXT);
        }

        [Obsolete]
        public void AddClassTypeSource(ITypeSource typeSource)
        {
            AddTypeSource(typeSource);
        }

        public void AddTypeSource(ITypeSource typeSource, string contextName)
        {
            if (contextName == null)
                contextName = DEFAULT_CONTEXT;

            if (!_contexts.ContainsKey(contextName))
            {
                _contexts.Add(contextName, CreateContext());
            }
            _contexts[contextName].AddTypeSource(typeSource);
        }

        [Obsolete]
        public void AddClassTypeSource(ITypeSource typeSource, string contextName)
        {
            AddTypeSource(typeSource, contextName);
        }

        public ITypeResolverContext InContext(string contextName)
        {
            if (!_contexts.ContainsKey(contextName))
            {
                throw new InvalidOperationException($"contextName '{contextName}' does not exist.");
            }

            return _contexts[contextName];
        }

        public IEnumerable<ITemplateDependency> GetTemplateDependencies()
        {
            return _contexts.Values
                .SelectMany(x => x.TypeSources)
                .SelectMany(x => x.GetTemplateDependencies())
                .ToList();
        }

        public IResolvedTypeInfo Get(IClassProvider classProvider)
        {
            var context = InContext(DEFAULT_CONTEXT);

            return context.Get(classProvider);
        }

        public IResolvedTypeInfo Get(ITypeReference typeInfo)
        {
            return Get(typeInfo, null);
        }

        public IResolvedTypeInfo Get(ITypeReference typeInfo, string collectionFormat)
        {
            var context = InContext(DEFAULT_CONTEXT);

            return context.Get(typeInfo, collectionFormat);
        }

        public IResolvedTypeInfo Get(ICanBeReferencedType element)
        {
            return Get(element, null);
        }

        public IResolvedTypeInfo Get(ICanBeReferencedType element, string collectionFormat)
        {
            var context = InContext(DEFAULT_CONTEXT);
            var typeReference = element.AsTypeReference();

            return context.Get(typeReference, collectionFormat);
        }
    }

    /// <summary>
    /// Extension methods for <see cref="ICanBeReferencedType"/>.
    /// </summary>
    public static class CanBeReferencedTypeExtensions
    {
        /// <summary>
        /// Converts <see cref="ICanBeReferencedType"/> to type of <see cref="ITypeReference"/>
        /// </summary>
        public static ITypeReference AsTypeReference(this ICanBeReferencedType type)
        {
            return new ElementTypeReference(type);
        }

        /// <summary>
        /// Converts <see cref="ICanBeReferencedType"/> to type of <see cref="ITypeReference"/>
        /// </summary>
        public static ITypeReference AsTypeReference(this ICanBeReferencedType type, bool isNullable, bool isCollection)
        {
            return new ElementTypeReference(type, isNullable, isCollection);
        }

        private class ElementTypeReference : ITypeReference, IHasStereotypes
        {
            public ElementTypeReference(ICanBeReferencedType element, bool isNullable = false, bool isCollection = false)
            {
                Element = element;
                IsNullable = isNullable;
                IsCollection = isCollection;
            }

            public bool IsNullable { get; }
            public bool IsCollection { get; }
            public ICanBeReferencedType Element { get; }
            public IEnumerable<ITypeReference> GenericTypeParameters { get; } = Array.Empty<ITypeReference>();
            public string Comment { get; } = null;
            public IEnumerable<IStereotype> Stereotypes { get; } = new List<IStereotype>();
        }
    }
}
