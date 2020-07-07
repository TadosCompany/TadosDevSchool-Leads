namespace Autofac.Extensions.TypedFactories.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class TypeExtensions
    {
        public static Type Map(this Type type, IDictionary<Type, Type> typesMap)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (typesMap == null)
                throw new ArgumentNullException(nameof(typesMap));

            if (!type.IsGenericType)
                return typesMap.ContainsKey(type) ? typesMap[type] : type;

            Type[] arguments = type.GenericTypeArguments;

            for (var i = 0; i < arguments.Length; i++)
            {
                arguments[i] = arguments[i].Map(typesMap);
            }

            return type.GetGenericTypeDefinition().MakeGenericType(arguments);
        }

        public static Type[] Map(this IEnumerable<Type> types, IDictionary<Type, Type> typesMap)
        {
            return types.Select(x => x.Map(typesMap)).ToArray();
        }
    }
}
