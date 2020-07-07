namespace Autofac.Extensions.TypedFactories.Base
{
    using Autofac;

    public abstract class FactoryBase
    {
        protected readonly IComponentContext ComponentContext;



        protected FactoryBase(IComponentContext componentContext)
        {
            ComponentContext = componentContext;
        }
    }
}
