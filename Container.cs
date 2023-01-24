﻿using System.Reflection;

namespace XorterDI;

public class Container
{
    private Dictionary<Type, object> Bindings { get; set; } = new();

    public void Bind<T>(T value)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));

        Bindings.Add(typeof(T), value);
    }

    public void Inject<T>(T value)
    {
        Type type = value.GetType();

        MethodInfo method = GetInjectMethod(type);
        object[] values = GetParametersValues(method);

        method.Invoke(value, values);
    }

    private static MethodInfo GetInjectMethod(Type type)
    {
        MethodInfo[] methods = type.GetMethods();

        return methods.Single(m => m.GetCustomAttribute<InjectAttribute>() is not null);
    }

    private object[] GetParametersValues(MethodInfo method)
    {
        ParameterInfo[] parameters = method.GetParameters();

        var result = new object[parameters.Length];

        for (int i = 0; i < parameters.Length; i++)
        {
            Type type = parameters[i].ParameterType;

            result[i] = Bindings.First(b => b.Key == type).Value;
        }

        return result;
    }
}
