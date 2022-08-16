using UnityEngine;

public class LogManager : MonoBehaviour
{
    public static void LogError(string message)
    {
        Debug.LogError(message);
    }

    public static void LogMessage(string message)
    {
        Debug.Log("TicTacToe: " + message);
    }
}