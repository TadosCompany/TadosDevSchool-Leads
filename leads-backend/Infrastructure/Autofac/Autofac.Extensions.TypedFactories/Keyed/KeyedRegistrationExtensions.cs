namespace Autofac.Extensions.TypedFactories.Keyed
{
    using System;
    using Builder;
    using Features.Scanning;

    public static class KeyedRegistrationExtensions
    {
        public static IRegistrationBuilder<TService, ConcreteReflectionActivatorData, SingleRegistrationStyle> Keyed<TService>(
            this IRegistrationBuilder<TService, ConcreteReflectionActivatorData, SingleRegistrationStyle> registrationBuilder, 
            object serviceKey1, 
            object serviceKey2)
        {
            return registrationBuilder.Keyed<TService>((serviceKey1, serviceKey2));
        }

        public static IRegistrationBuilder<TService, ConcreteReflectionActivatorData, SingleRegistrationStyle> Keyed<TService>(
            this IRegistrationBuilder<TService, ConcreteReflectionActivatorData, SingleRegistrationStyle> registrationBuilder,
            object serviceKey1,
            object serviceKey2,
            object serviceKey3)
        {
            return registrationBuilder.Keyed<TService>((serviceKey1, serviceKey2, serviceKey3));
        }

        public static IRegistrationBuilder<TService, ConcreteReflectionActivatorData, SingleRegistrationStyle> Keyed<TService>(
            this IRegistrationBuilder<TService, ConcreteReflectionActivatorData, SingleRegistrationStyle> registrationBuilder,
            object serviceKey1,
            object serviceKey2,
            object serviceKey3,
            object serviceKey4)
        {
            return registrationBuilder.Keyed<TService>((serviceKey1, serviceKey2, serviceKey3, serviceKey4));
        }

        public static IRegistrationBuilder<TService, ConcreteReflectionActivatorData, SingleRegistrationStyle> Keyed<TService>(
            this IRegistrationBuilder<TService, ConcreteReflectionActivatorData, SingleRegistrationStyle> registrationBuilder,
            object serviceKey1,
            object serviceKey2,
            object serviceKey3,
            object serviceKey4,
            object serviceKey5)
        {
            return registrationBuilder.Keyed<TService>((serviceKey1, serviceKey2, serviceKey3, serviceKey4, serviceKey5));
        }



        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> Keyed<TService>(
            this IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> registrationBuilder,
            Func<Type, object> serviceKey1Mapping,
            Func<Type, object> serviceKey2Mapping)
        {
            return registrationBuilder.Keyed<TService>(type => 
                (
                    serviceKey1Mapping(type),
                    serviceKey2Mapping(type)
                ));
        }

        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> Keyed<TService>(
            this IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> registrationBuilder,
            Func<Type, object> serviceKey1Mapping,
            Func<Type, object> serviceKey2Mapping,
            Func<Type, object> serviceKey3Mapping)
        {
            return registrationBuilder.Keyed<TService>(type =>
                (
                    serviceKey1Mapping(type),
                    serviceKey2Mapping(type),
                    serviceKey3Mapping(type)
                ));
        }

        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> Keyed<TService>(
            this IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> registrationBuilder,
            Func<Type, object> serviceKey1Mapping,
            Func<Type, object> serviceKey2Mapping,
            Func<Type, object> serviceKey3Mapping,
            Func<Type, object> serviceKey4Mapping)
        {
            return registrationBuilder.Keyed<TService>(type =>
                (
                    serviceKey1Mapping(type),
                    serviceKey2Mapping(type),
                    serviceKey3Mapping(type),
                    serviceKey4Mapping(type)
                ));
        }

        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> Keyed<TService>(
            this IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> registrationBuilder,
            Func<Type, object> serviceKey1Mapping,
            Func<Type, object> serviceKey2Mapping,
            Func<Type, object> serviceKey3Mapping,
            Func<Type, object> serviceKey4Mapping,
            Func<Type, object> serviceKey5Mapping)
        {
            return registrationBuilder.Keyed<TService>(type =>
                (
                    serviceKey1Mapping(type),
                    serviceKey2Mapping(type),
                    serviceKey3Mapping(type),
                    serviceKey4Mapping(type),
                    serviceKey5Mapping(type)
                ));
        }
    }
}
