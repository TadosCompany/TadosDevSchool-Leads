namespace Autofac.Extensions.TypedFactories.Runtime
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Autofac;
    using Base;
    using Extensions;

    public abstract class RuntimeFactoryBase : FactoryBase
    {
        protected RuntimeFactoryBase(IComponentContext componentContext)
            : base(componentContext)
        {
        }



        protected object Resolve(MethodInfo methodInfo, Type[] parametersTypes)
        {
            return ComponentContext.Resolve(CreateType(methodInfo, parametersTypes));
        }

        protected static MethodInfo GetMethodInfo(MethodBase methodBase)
        {
            Type methodDeclaringType = methodBase.DeclaringType;
            string methodName = methodBase.Name;
            Type[] methodParametersTypes = methodBase.GetParameters().Select(x => x.ParameterType).ToArray();
            
            return methodDeclaringType.GetMethod(methodName, methodParametersTypes);
        }



        protected static Type CreateType(
            MethodInfo methodInfo,
            Type[] parametersRuntimeTypes)
        {
            if (methodInfo == null)
                throw new ArgumentNullException(nameof(methodInfo));

            if (parametersRuntimeTypes == null)
                throw new ArgumentNullException(nameof(parametersRuntimeTypes));

            Type returnType = methodInfo.ReturnType;
            Type[] genericArgumentsTypes = methodInfo.GetGenericArguments();
            Type[] parametersTypes = methodInfo.GetParameters().Select(x => x.ParameterType).ToArray();

            var typesMap = new Dictionary<Type, Type>();

            for (var i = 0; i < parametersTypes.Length; i++)
            {
                typesMap = typesMap.Merge(
                    GetTypesMap(
                        genericArgumentsTypes,
                        parametersTypes[i],
                        parametersRuntimeTypes[i]));
            }

            return returnType.Map(typesMap);
        }

        private static Dictionary<Type, Type> GetTypesMap(
            Type[] genericArguments,
            Type type,
            Type runtimeType)
        {
            if (genericArguments == null)
                throw new ArgumentNullException(nameof(genericArguments));

            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (runtimeType == null)
                throw new ArgumentNullException(nameof(runtimeType));

            var typesMap = new Dictionary<Type, Type>();

            if (genericArguments.Contains(type))
            {
                typesMap.Add(type, runtimeType);

                foreach (Type genericParameterTypeConstraint in type.GetGenericParameterConstraints())
                {
                    typesMap = typesMap.Merge(
                        GetTypesMap(
                            genericArguments,
                            genericParameterTypeConstraint,
                            runtimeType));

                    if (genericParameterTypeConstraint.IsGenericType)
                    {
                        Type[] genericParameterTypeConstraintGenericArguments = genericParameterTypeConstraint.GetGenericArguments();

                        Type accordingRuntimeBaseType = FindBaseTypeAccordingToGenericTypeDefinition(
                            runtimeType,
                            genericParameterTypeConstraint.GetGenericTypeDefinition());

                        Type[] accordingRuntimeBaseTypeGenericArguments = accordingRuntimeBaseType.GetGenericArguments();

                        for (var i = 0; i < genericParameterTypeConstraintGenericArguments.Length; i++)
                        {
                            typesMap = typesMap.Merge(
                                GetTypesMap(
                                    genericArguments,
                                    genericParameterTypeConstraintGenericArguments[i],
                                    accordingRuntimeBaseTypeGenericArguments[i]));
                        }
                    }
                }
            }

            return typesMap;
        }

        private static Type FindBaseTypeAccordingToGenericTypeDefinition(Type type, Type genericTypeDefinition)
        {
            if (genericTypeDefinition.IsInterface)
            {
                foreach (Type @interface in type.GetInterfaces())
                {
                    if (@interface.IsClosedTypeOf(genericTypeDefinition))
                        return @interface;
                }
            }
            else
            {
                Type baseType = type.BaseType;

                if (baseType != null)
                {
                    if (type.BaseType.IsClosedTypeOf(genericTypeDefinition))
                        return type.BaseType;

                    return FindBaseTypeAccordingToGenericTypeDefinition(baseType, genericTypeDefinition);
                }
            }

            throw new Exception("Base type according to generic type definition not found");
        }
    }
}
