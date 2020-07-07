namespace Autofac.Extensions.TypedFactories.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;

    public static class MethodBuilderExtensions
    {
        public static MethodBuilder DefineReturnType(this MethodBuilder methodBuilder, Type returnType)
        {
            if (methodBuilder == null)
                throw new ArgumentNullException(nameof(methodBuilder));

            if (returnType == null)
                throw new ArgumentNullException(nameof(returnType));

            methodBuilder.SetReturnType(returnType);

            return methodBuilder;
        }

        public static MethodBuilder DefineParameters(this MethodBuilder methodBuilder, IDictionary<Type, Type> typesMap, params ParameterInfo[] parameters)
        {
            if (methodBuilder == null)
                throw new ArgumentNullException(nameof(methodBuilder));

            if (typesMap == null)
                throw new ArgumentNullException(nameof(typesMap));

            if (parameters.Any())
            {
                Type[] parameterTypes = parameters.Select(x => x.ParameterType).Map(typesMap);

                methodBuilder.SetParameters(parameterTypes);

                for (var i = 0; i < parameters.Length; i++)
                {
                    methodBuilder.DefineParameter(i + 1, parameters[i].Attributes, parameters[i].Name);
                }
            }

            return methodBuilder;
        }

        public static MethodBuilder DefineGenericParameters(this MethodBuilder methodBuilder, IDictionary<Type, Type> typesMap, params Type[] parameters)
        {
            if (methodBuilder == null)
                throw new ArgumentNullException(nameof(methodBuilder));

            if (parameters.Any())
            {
                string[] genericParameterNames = parameters.Select(x => x.Name).ToArray();

                GenericTypeParameterBuilder[] genericTypeParameterBuilders =
                    methodBuilder.DefineGenericParameters(genericParameterNames);

                for (var i = 0; i < parameters.Length; i++)
                {
                    genericTypeParameterBuilders[i].ApplyGenericParameterConstraints(
                        parameters[i]
                            .GetGenericParameterConstraints()
                            .Map(typesMap));

                    genericTypeParameterBuilders[i].ApplyGenericParameterAttributes(
                        parameters[i]
                            .GetTypeInfo()
                            .GenericParameterAttributes);
                }
            }

            return methodBuilder;
        }
    }
}
