namespace Autofac.Extensions.TypedFactories.Keyed
{
    public static class KeyedResolutionExtensions
    {
        public static TService ResolveKeyed<TService>(
            this IComponentContext context,
            object serviceKey)
        {
            return ResolutionExtensions.ResolveKeyed<TService>(context, serviceKey);
        }

        public static TService ResolveKeyed<TService>(
            this IComponentContext context, 
            object serviceKey1, 
            object serviceKey2)
        {
            return context.ResolveKeyed<TService>((serviceKey1, serviceKey2));
        }

        public static TService ResolveKeyed<TService>(
            this IComponentContext context, 
            object serviceKey1, 
            object serviceKey2,
            object serviceKey3)
        {
            return context.ResolveKeyed<TService>((serviceKey1, serviceKey2, serviceKey3));
        }

        public static TService ResolveKeyed<TService>(
            this IComponentContext context, 
            object serviceKey1, 
            object serviceKey2,
            object serviceKey3,
            object serviceKey4)
        {
            return context.ResolveKeyed<TService>((serviceKey1, serviceKey2, serviceKey3, serviceKey4));
        }

        public static TService ResolveKeyed<TService>(
            this IComponentContext context, 
            object serviceKey1, 
            object serviceKey2,
            object serviceKey3,
            object serviceKey4,
            object serviceKey5)
        {
            return context.ResolveKeyed<TService>((serviceKey1, serviceKey2, serviceKey3, serviceKey4, serviceKey5));
        }
    }
}
