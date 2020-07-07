namespace Autofac.Extensions.TypedFactories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;
    using Base;
    using Generic;
    using Keyed;
    using Runtime;

    public static class FactoryContext
    {
        private const string DynamicAssemblyName = "AutofacDynamicAssembly";
        private const string DynamicModuleName = "Factories";
        public const string DynamicFactoryTypeSuffix = "_Implementation";
        
        private static readonly AssemblyBuilder AssemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(
            new AssemblyName(DynamicAssemblyName),
            AssemblyBuilderAccess.Run);

        public static readonly ModuleBuilder ModuleBuilder = AssemblyBuilder.DefineDynamicModule(DynamicModuleName);



        public static readonly Type GenericFactoryBaseType = typeof(GenericFactoryBase);
        public static readonly Type KeyedFactoryBaseType = typeof(KeyedFactoryBase);
        public static readonly Type RuntimeFactoryBaseType = typeof(RuntimeFactoryBase);



        public static ConstructorInfo FactoryBaseConstructorInfo(Type factoryBaseType) => factoryBaseType
            .GetMatchingConstructor(
                new[]
                {
                    typeof(IComponentContext)
                });



        private const string FactoryComponentContextFieldName = "ComponentContext";

        public static readonly FieldInfo FactoryBaseComponentContextFieldInfo = typeof(FactoryBase)
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .Single(x => x.Name == FactoryComponentContextFieldName);



        public static readonly MethodInfo ResolveMethodInfo = typeof(ResolutionExtensions)
            .GetMethods()
            .Single(x =>
                x.Name == "Resolve" &&
                !x.IsGenericMethod &&
                x.GetParameters().Length == 2);



        public static readonly MethodInfo ResolveGenericMethodInfo = typeof(ResolutionExtensions)
            .GetMethods()
            .Single(x =>
                x.Name == "Resolve" &&
                x.IsGenericMethod &&
                x.GetParameters().Length == 1);



        public static MethodInfo ResolveKeyedGenericMethodInfo(int keysCount)
        {
            if (keysCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(keysCount));

            return typeof(KeyedResolutionExtensions)
                .GetMethods()
                .Single(x =>
                    x.Name == "ResolveKeyed" &&
                    x.IsGenericMethod &&
                    x.GetParameters().Length == 1 + keysCount);
        }
    }
}
