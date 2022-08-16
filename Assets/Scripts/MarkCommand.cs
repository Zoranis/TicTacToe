namespace DefaultNamespace
{
    public class MarkCommand : ICommand
    {
        public Mark PlayerMark;
        public GridPosition GridPosition;


        public MarkCommand(Mark playerMark, GridPosition gridPosition)
        {
            PlayerMark = playerMark;
            GridPosition = gridPosition;
        }

        public void Execute()
        {
            GameManager.Instance.SetMark(GridPosition, PlayerMark);
        }

        public void Undo()
        {
            GameManager.Instance.SetMark(GridPosition, Mark.Empty);
        }
    }
}