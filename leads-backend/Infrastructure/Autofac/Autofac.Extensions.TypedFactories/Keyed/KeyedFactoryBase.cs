namespace Autofac.Extensions.TypedFactories.Keyed
{
    using Autofac;
    using Base;

    public abstract class KeyedFactoryBase : FactoryBase
    {
        protected KeyedFactoryBase(IComponentContext componentContext)
            : base(componentContext)
        {
        }
    }
}
