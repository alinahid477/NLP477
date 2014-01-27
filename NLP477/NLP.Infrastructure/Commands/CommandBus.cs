using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Infrastructure.Commands
{
    public class CommandBus : ICommandBus
    {
        IKernel ninjectContainer;
        ICommandLogger commandLogger;

        private Dictionary<Type, object> commandHandlers = new Dictionary<Type, object>();

        public CommandBus(IKernel kernel, ICommandLogger commandLogger)
        {
            this.ninjectContainer = kernel;
            this.commandLogger = commandLogger;
        }

        public void Send<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            try
            {

                // see: https://github.com/rmacdonaldsmith/CQRSExample/blob/master/src/Domain/ServiceBus/InMemoryServiceBus.cs

                Type ifaceType = typeof(Handles<>);
                Type[] commandTypeArgs = { command.GetType() };
                Type genericHandlerType = ifaceType.MakeGenericType(commandTypeArgs);


                var commandHandler = this.ninjectContainer.Get(genericHandlerType);

                ((dynamic)commandHandler).Handle(command as dynamic); // i don't understand why this works! (Jon)
                command.CommandStatus = CommandStatus.Handled;

            }
            catch (Ninject.ActivationException activationException)
            {
                command.CommandStatus = CommandStatus.RejectedNoHandler;
                throw new InvalidOperationException(
                    string.Format("There are no command handlers subscribed to handle commands of type '{0}'",
                                  command.GetType().Name), activationException);
            }
            finally
            {
                //commandLogger.LogCommand(command);
            }

        }

    }
}
