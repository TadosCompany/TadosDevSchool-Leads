namespace Autofac.Extensions.TypedFactories
{
    using System;
    using Autofac;
    using Builder;
    using Generic;
    using Keyed;
    using Runtime;

    public static class FactoryExtensions
    {
        public static IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle>
            RegisterGenericTypedFactory<TFactoryService>(this ContainerBuilder builder)
            where TFactoryService : class
            => builder.RegisterTypedFactory<TFactoryService>(GenericFactoryBuilder.Create<TFactoryService>());

        public static IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle> 
            RegisterKeyedTypedFactory<TFactoryService>(this ContainerBuilder builder)
            where TFactoryService : class
            => builder.RegisterTypedFactory<TFactoryService>(KeyedFactoryBuilder.Create<TFactoryService>());

        public static IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle> 
            RegisterRuntimeTypedFactory<TFactoryService>(this ContainerBuilder builder)
            where TFactoryService : class
            => builder.RegisterTypedFactory<TFactoryService>(RuntimeFactoryBuilder.Create<TFactoryService>());



        private static IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle> RegisterTypedFactory<TFactoryService>(
            this ContainerBuilder builder,
            Type factoryType)
            where TFactoryService : class
        {
            return builder.RegisterType(factoryType).As<TFactoryService>();
        }
    }
}
