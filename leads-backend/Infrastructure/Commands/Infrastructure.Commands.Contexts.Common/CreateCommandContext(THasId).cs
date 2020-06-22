namespace Infrastructure.Commands.Contexts.Common
{
    using System;
    using Abstractions;
    using Identification.Abstractions;


    public class CreateCommandContext<THasId> : ICommandContext
        where THasId : class, IHasId, new()
    {
        public CreateCommandContext(THasId objectWithId)
        {
            ObjectWithId = objectWithId ?? throw new ArgumentNullException(nameof(objectWithId));
        }


        public THasId ObjectWithId { get; }
    }
}