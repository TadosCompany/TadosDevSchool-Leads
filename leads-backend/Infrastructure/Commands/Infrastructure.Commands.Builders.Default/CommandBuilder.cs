namespace Infrastructure.Commands.Builders.Default
{
    using System;
    using Abstractions;
    using Contexts.Abstractions;
    using Factories.Abstractions;


    public class CommandBuilder : ICommandBuilder
    {
        private readonly ICommandFactory _commandFactory;


        public CommandBuilder(ICommandFactory commandFactory)
        {
            _commandFactory = commandFactory ?? throw new ArgumentNullException(nameof(commandFactory));
        }


        public void Execute<TCommandContext>(TCommandContext commandContext) where TCommandContext : ICommandContext
        {
            _commandFactory.Create<TCommandContext>().Execute(commandContext);
        }
    }
}