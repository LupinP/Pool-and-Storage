using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public static class ToolsSetter
{
    [MenuItem("Tools/Init")]
    public static void Initialize()
    {
        InvokeMethodAtAttribute<SetSettings>();
    }

    public static void InvokeMethodAtAttribute<T>() where T : Attribute
    {
        var methods = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => x.IsClass)
            .SelectMany(x => x.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
            .Where(x => x.GetCustomAttributes(typeof(T), false)
                .FirstOrDefault() != null);

        foreach (var method in methods)
        {
            if (method.IsStatic)
            {
                method.Invoke(null, null);
            }
        }
    }
}