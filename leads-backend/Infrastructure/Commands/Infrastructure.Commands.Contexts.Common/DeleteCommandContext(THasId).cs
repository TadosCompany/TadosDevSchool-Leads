namespace Infrastructure.Commands.Contexts.Common
{
    using System;
    using Abstractions;
    using Identification.Abstractions;


    public class DeleteCommandContext<THasId> : ICommandContext
        where THasId : IHasId
    {
        public DeleteCommandContext(THasId objectWithId)
        {
            ObjectWithId = objectWithId ?? throw new ArgumentNullException(nameof(objectWithId));
        }


        public THasId ObjectWithId { get; }
    }
}