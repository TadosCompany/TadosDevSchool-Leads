namespace Autofac.Extensions.TypedFactories.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;


    public class FactoryBuilder
    {
        private static readonly object LockObject = new object();
        private static readonly Dictionary<Type, Type> FactoriesCache = new Dictionary<Type, Type>();


        public static Type Create<TFactory>(
            Type baseType,
            ConstructorInfo constructorInfo,
            Action<TypeBuilder, IDictionary<Type, Type>, MethodInfo> defineMethod)
        {
            lock (LockObject)
            {
                Type factoryType = typeof(TFactory);

                if (FactoriesCache.ContainsKey(factoryType))
                    return FactoriesCache[factoryType];

                if (!factoryType.IsInterface)
                    throw new ArgumentException("Interface type expected");

                if (factoryType.ContainsGenericParameters)
                    throw new ArgumentException("Interface without generic parameters expected");


                // Collect all interfaces

                Type[] factoryTypeInterfaces = new[] {factoryType}.Concat(factoryType.GetInterfaces()).ToArray();


                // Create types map

                var typesMapPairs = new List<KeyValuePair<Type, Type>>();

                foreach (Type factoryTypeInterface in factoryTypeInterfaces)
                {
                    typesMapPairs.AddRange(CreateGenericParameterToGenericArgumentTypesMapPairs(factoryTypeInterface));
                }

                IDictionary<Type, Type> typesMap = typesMapPairs.ToDictionary(x => x.Key, x => x.Value);


                // Define type based on baseType with factoryType interface implementation

                TypeBuilder typeBuilder =
                    FactoryContext.ModuleBuilder.DefineType(factoryType.Name + FactoryContext.DynamicFactoryTypeSuffix);
                typeBuilder.SetParent(baseType);
                typeBuilder.AddInterfaceImplementation(factoryType);


                // Define constructor

                ConstructorBuilder constructorBuilder = typeBuilder.DefineConstructor(
                    MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.SpecialName |
                    MethodAttributes.RTSpecialName,
                    CallingConventions.Standard,
                    new[]
                    {
                        typeof(IComponentContext)
                    });

                ILGenerator constructorGenerator = constructorBuilder.GetILGenerator();

                constructorGenerator.Emit(OpCodes.Ldarg_0);
                constructorGenerator.Emit(OpCodes.Ldarg_1);
                constructorGenerator.Emit(OpCodes.Call, constructorInfo);
                constructorGenerator.Emit(OpCodes.Ret);


                // Define methods

                foreach (Type factoryTypeInterface in factoryTypeInterfaces)
                {
                    foreach (MethodInfo factoryTypeMethodInfo in factoryTypeInterface.GetMethods())
                    {
                        defineMethod(typeBuilder, typesMap, factoryTypeMethodInfo);
                    }
                }


                // Create and return type

                Type type = typeBuilder.CreateTypeInfo().AsType();

                FactoriesCache[factoryType] = type;
                
                return type;
            }
        }


        private static IEnumerable<KeyValuePair<Type, Type>>
            CreateGenericParameterToGenericArgumentTypesMapPairs(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (!type.IsGenericType)
                return new Dictionary<Type, Type>();

            if (type.ContainsGenericParameters)
                throw new ArgumentException("Interface without generic parameters expected");

            Type genericTypeDefinition = type.GetGenericTypeDefinition();

            if (genericTypeDefinition.GenericTypeArguments.Any())
                throw new ArgumentException("Type only with generic parameters expected", nameof(type));

            Type[] genericParameters = genericTypeDefinition.GetTypeInfo().GenericTypeParameters;
            Type[] genericArguments = type.GenericTypeArguments;

            var map = new List<KeyValuePair<Type, Type>>();

            for (var i = 0; i < genericParameters.Length; i++)
            {
                map.Add(
                    new KeyValuePair<Type, Type>(
                        genericParameters[i],
                        genericArguments[i]));
            }

            return map.AsEnumerable();
        }
    }
}