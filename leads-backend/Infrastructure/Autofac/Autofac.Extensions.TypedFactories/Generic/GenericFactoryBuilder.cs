namespace Autofac.Extensions.TypedFactories.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;
    using Base;
    using Extensions;

    public static class GenericFactoryBuilder
    {
        public static Type Create<TFactory>() => FactoryBuilder.Create<TFactory>(
            FactoryContext.GenericFactoryBaseType,
            FactoryContext.FactoryBaseConstructorInfo(FactoryContext.GenericFactoryBaseType),
            DefineMethod);



        private static void DefineMethod(TypeBuilder typeBuilder, IDictionary<Type, Type> typesMap, MethodInfo methodInfo)
        {
            if (methodInfo.GetParameters().Any())
                throw new InvalidOperationException("Method without parameters expected");

            MethodBuilder methodBuilder = typeBuilder
                .DefineMethod(
                    methodInfo.Name,
                    MethodAttributes.Public | MethodAttributes.Virtual)
                .DefineReturnType(methodInfo.ReturnType)
                .DefineGenericParameters(
                    typesMap,
                    methodInfo.GetGenericArguments());

            ILGenerator methodGenerator = methodBuilder.GetILGenerator();

            // Push this.IComponentContext

            methodGenerator.Emit(OpCodes.Ldarg_0);
            methodGenerator.Emit(OpCodes.Ldfld, FactoryContext.FactoryBaseComponentContextFieldInfo);

            // Return ResolutionExtensions.Resolve<ReturnType>(ComponentContext) method result

            methodGenerator.Emit(OpCodes.Call, FactoryContext.ResolveGenericMethodInfo.MakeGenericMethod(methodInfo.ReturnType));
            methodGenerator.Emit(OpCodes.Ret);
        }
    }
}
