namespace Autofac.Extensions.TypedFactories.Runtime
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Reflection.Emit;
    using Base;
    using Extensions;

    public static class RuntimeFactoryBuilder
    {
        public static Type Create<TFactory>() => FactoryBuilder.Create<TFactory>(
            FactoryContext.RuntimeFactoryBaseType,
            FactoryContext.FactoryBaseConstructorInfo(FactoryContext.RuntimeFactoryBaseType),
            DefineMethod);



        private static void DefineMethod(TypeBuilder typeBuilder, IDictionary<Type, Type> typesMap, MethodInfo methodInfo)
        {
            ParameterInfo[] parametersInfo = methodInfo.GetParameters();
            
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

            methodGenerator.Emit(OpCodes.Ldarg_0);
            methodGenerator.Emit(OpCodes.Call, typeof(MethodBase).GetMethod("GetCurrentMethod"));
            methodGenerator.Emit(OpCodes.Call, typeof(RuntimeFactoryBase).GetMethod("GetMethodInfo", BindingFlags.Static | BindingFlags.NonPublic));
            
            methodGenerator.Emit(OpCodes.Ldc_I4, parametersInfo.Length);
            methodGenerator.Emit(OpCodes.Newarr, typeof(Type));
            
            for (var i = 0; i < parametersInfo.Length; i++)
            {
                methodGenerator.Emit(OpCodes.Dup);
                methodGenerator.Emit(OpCodes.Ldc_I4, i);
                methodGenerator.Emit(OpCodes.Ldarg, i + 1);

                Type parameterType = parametersInfo[i].ParameterType.Map(typesMap);

                if (parameterType.IsValueType)
                {
                    methodGenerator.Emit(OpCodes.Box, parameterType);
                }

                methodGenerator.Emit(OpCodes.Callvirt, typeof(object).GetMethod("GetType"));
                methodGenerator.Emit(OpCodes.Stelem_Ref);
            }
            
            methodGenerator.Emit(OpCodes.Call, typeof(RuntimeFactoryBase).GetMethod("Resolve", BindingFlags.Instance | BindingFlags.NonPublic));
            methodGenerator.Emit(OpCodes.Ret);
        }
    }
}
