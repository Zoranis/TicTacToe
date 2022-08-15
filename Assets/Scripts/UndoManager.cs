using System.Collections.Generic;

namespace DefaultNamespace
{
    public class UndoManager
    {
        private Stack<ICommand> Commands;

        public UndoManager(Stack<ICommand> commands)
        {
            Commands = commands;
        }
    }
}