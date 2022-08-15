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
            GameManager.SetMark(GridPosition, PlayerMark);
        }

        public void Undo()
        {
            GameManager.SetMark(GridPosition, Mark.Empty);
        }
    }
}