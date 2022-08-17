using System.Collections.Generic;

namespace TicTacToe
{
    public class UndoManager
    {
        private Stack<ICommand> CommandHistory;

        public UndoManager()
        {
            CommandHistory = new Stack<ICommand>();
        }

        public void StackCommand(ICommand command)
        {
            CommandHistory.Push(command);
        }

        public void UndoLastCommand()
        {
            ICommand lastCommand = CommandHistory.Pop();
            lastCommand.Undo();
        }
        
    }
}