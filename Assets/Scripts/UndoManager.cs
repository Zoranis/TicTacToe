using System.Collections.Generic;

namespace DefaultNamespace
{
    public class UndoManager
    {
        private Stack<ICommand> CommandHistory;
        private Stack<ICommand> UndoHistory;

        public UndoManager()
        {
            CommandHistory = new Stack<ICommand>();
            UndoHistory = new Stack<ICommand>();
        }

        public void StackCommand(ICommand command)
        {
            CommandHistory.Push(command);
            //New commands make undo history irrelevant, so UndoHistory is cleaned.
            UndoHistory.Clear();
        }

        public void UndoLastCommand()
        {
            ICommand lastCommand = CommandHistory.Pop();
            lastCommand.Undo();
            UndoHistory.Push(lastCommand);
        }

        public void Redo()
        {
            ICommand lastUndoCommand = UndoHistory.Pop();
            lastUndoCommand.Execute();
            CommandHistory.Push(lastUndoCommand);
        }
        
    }
}