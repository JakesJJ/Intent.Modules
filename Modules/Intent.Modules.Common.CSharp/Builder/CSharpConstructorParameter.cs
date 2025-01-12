using System;
using Intent.Modules.Common.CSharp.Templates;
using Intent.Modules.Common.Templates;
using JetBrains.Annotations;

namespace Intent.Modules.Common.CSharp.Builder;

public class CSharpConstructorParameter
{
    private readonly CSharpConstructor _constructor;
    public string Type { get; }
    public string Name { get; }

    public CSharpConstructorParameter(string type, string name, CSharpConstructor constructor)
    {
        if (string.IsNullOrWhiteSpace(type))
        {
            throw new ArgumentException("Cannot be null or empty", nameof(type));
        }
        
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Cannot be null or empty", nameof(name));
        }
        
        _constructor = constructor;
        Type = type;
        Name = name;
    }
    public CSharpConstructorParameter IntroduceField(Action<CSharpField> configure = null)
    {
        return IntroduceField((field, _) => configure?.Invoke(field));
    }

    public CSharpConstructorParameter IntroduceField(Action<CSharpField, CSharpFieldAssignmentStatement> configure)
    {
        _constructor.Class.AddField(Type, Name.ToPrivateMemberName(), field =>
        {
            var statement = new CSharpFieldAssignmentStatement(field.Name, Name);
            _constructor.AddStatement(statement);
            configure?.Invoke(field, statement);
        });
        return this;
    }

    public CSharpConstructorParameter IntroduceReadonlyField(Action<CSharpField> configure = null)
    {
        return IntroduceReadonlyField((field, _) => configure?.Invoke(field));
    }

    public CSharpConstructorParameter IntroduceReadonlyField(Action<CSharpField, CSharpFieldAssignmentStatement> configure)
    {
        return IntroduceField((field, statement) =>
        {
            field.PrivateReadOnly();
            configure?.Invoke(field, statement);
        });
    }

    public CSharpConstructorParameter IntroduceProperty(Action<CSharpProperty> configure = null)
    {
        return IntroduceProperty((property, _) => configure?.Invoke(property));
    }

    public CSharpConstructorParameter IntroduceProperty(Action<CSharpProperty, CSharpFieldAssignmentStatement> configure)
    {
        _constructor.Class.AddProperty(Type, Name.ToPascalCase(), property =>
        {
            var statement = new CSharpFieldAssignmentStatement(property.Name, Name);
            _constructor.AddStatement(statement);
            configure?.Invoke(property, statement);
        });
        return this;
    }

    public override string ToString()
    {
        return $@"{Type} {Name}";
    }
}