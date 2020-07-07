namespace Autofac.Extensions.TypedFactories.Generic
{
    using Autofac;
    using Base;

    public abstract class GenericFactoryBase : FactoryBase
    {
        protected GenericFactoryBase(IComponentContext componentContext)
            : base(componentContext)
        {
        }
    }
}
