using System.Collections.Generic;

namespace DefaultNamespace
{
    public class UndoManager
    {
        private Stack<ICommand> CommandHistory;
        private Stack<ICommand> UndoHistory;

        public UndoManager(Stack<ICommand> undoHistory)
        {
            CommandHistory = new Stack<ICommand>();
            UndoHistory = new Stack<ICommand>();
        }

        public void StackCommand(ICommand command)
        {
            CommandHistory.Push(command);
        }

        public void UndoLastCommand()
        {
            ICommand lastCommand = CommandHistory.Pop();
            lastCommand.Undo();
            UndoHistory.Push(lastCommand);
        }

        public void Redo()
        {
            
        }
        
    }
}