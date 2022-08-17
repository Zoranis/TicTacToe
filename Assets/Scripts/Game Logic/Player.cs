public enum Mark
{
    X,
    O,
    Empty
}
    
public class Player
{
    private Mark _playerMark;

    public Mark PlayerMark
    {
        get => _playerMark;
        set => _playerMark = value;
    }
}