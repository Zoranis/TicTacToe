namespace DefaultNamespace
{
    public class MarkCommand : ICommand
    {
        public Mark PlayerMark;
        public GameManager GameManager;
        public GridPosition GridPosition;


        public MarkCommand(Mark playerMark, GameManager gameManager, GridPosition gridPosition)
        {
            PlayerMark = playerMark;
            GameManager = gameManager;
            GridPosition = gridPosition;
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }

        public void Undo()
        {
            throw new System.NotImplementedException();
        }
    }
}