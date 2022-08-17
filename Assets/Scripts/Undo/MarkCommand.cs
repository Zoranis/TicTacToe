namespace TicTacToe
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

        public bool Execute()
        {
            return GameManager.Instance.SetMark(GridPosition, PlayerMark);
        }

        public void Undo()
        {
            GameManager.Instance.SetMark(GridPosition, Mark.Empty);
        }
    }
}