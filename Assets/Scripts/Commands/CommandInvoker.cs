using System.Collections.Generic;
namespace Command.Commands
{
    /// A class responsible for invoking and managing commands.
    public class CommandInvoker
    {
        // A stack to keep track of executed commands.
        private Stack<ICommand> commandRegistry = new Stack<ICommand>();

        /// Process a command, which involves both executing it and registering it.
        /// The command to be processed.
        public void ProcessCommand(ICommand commandToProcess)
        {
            ExecuteCommand(commandToProcess);
            RegisterCommand(commandToProcess);
        }

        /// Execute a command, invoking its associated action.
        /// The command to be processed.
        public void ExecuteCommand(ICommand commandToExecute) => commandToExecute.Execute();

        /// Register a command by adding it to the command registry stack.
        /// //  The command to be registered
        public void RegisterCommand(ICommand commandToRegister) => commandRegistry.Push(commandToRegister);
    }
}