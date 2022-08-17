public enum Mark
{
    X,
    O,
    Empty
}
    
public class Player
{
    private Mark _playerMark;
    public string PlayerName;

    public Player(string playerName)
    {
        PlayerName = playerName;
    }

    public Mark PlayerMark
    {
        get => _playerMark;
        set => _playerMark = value;
    }
}