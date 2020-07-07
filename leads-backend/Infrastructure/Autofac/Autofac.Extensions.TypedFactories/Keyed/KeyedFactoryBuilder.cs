namespace Autofac.Extensions.TypedFactories.Keyed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;
    using Base;
    using Extensions;

    public static class KeyedFactoryBuilder
    {
        public static Type Create<TFactory>() => FactoryBuilder.Create<TFactory>(
            FactoryContext.KeyedFactoryBaseType,
            FactoryContext.FactoryBaseConstructorInfo(FactoryContext.KeyedFactoryBaseType),
            DefineMethod);



        private static void DefineMethod(TypeBuilder typeBuilder, IDictionary<Type, Type> typesMap, MethodInfo methodInfo)
        {
            ParameterInfo[] parametersInfo = methodInfo.GetParameters();

            if (parametersInfo.Length == 0)
                throw new InvalidOperationException("Method with at least 1 parameter expected");

            if (parametersInfo.Any(x => x.IsOut))
                throw new InvalidOperationException("Method with non out parameters expected");

            MethodBuilder methodBuilder = typeBuilder
                .DefineMethod(
                    methodInfo.Name,
                    MethodAttributes.Public | MethodAttributes.Virtual)
                .DefineReturnType(methodInfo.ReturnType)
                .DefineGenericParameters(
                    typesMap,
                    methodInfo.GetGenericArguments())
                .DefineParameters(
                    typesMap,
                    parametersInfo);

            ILGenerator methodGenerator = methodBuilder.GetILGenerator();

            // Push this.ComponentContext

            methodGenerator.Emit(OpCodes.Ldarg_0);
            methodGenerator.Emit(OpCodes.Ldfld, FactoryContext.FactoryBaseComponentContextFieldInfo);

            // Push (and box if it's value type) method arguments

            for (var i = 0; i < parametersInfo.Length; i++)
            {
                methodGenerator.Emit(OpCodes.Ldarg, i + 1);

                Type parameterType = parametersInfo[i].ParameterType.Map(typesMap);

                if (parameterType.IsValueType)
                {
                    methodGenerator.Emit(OpCodes.Box, parameterType);
                }
            }

            // Return KeyedResolutionExtensions.ResolveKeyed<ReturnType>(ComponentContext, methodArgument) method result

            methodGenerator.Emit(OpCodes.Call, FactoryContext.ResolveKeyedGenericMethodInfo(parametersInfo.Length).MakeGenericMethod(methodInfo.ReturnType));
            methodGenerator.Emit(OpCodes.Ret);
        }
    }
}
