using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusDisplay : MonoBehaviour
{
    [SerializeField] private Text TurnText;
    [SerializeField] private Text MarkText;
    [SerializeField] private Text MessageText;

    public void SetTurnText(string turn)
    {
        TurnText.text = "Turn: " + turn;
    }

    public void SetMarkText(string mark)
    {
        MarkText.text = "Mark: " + mark;
    }

    public void SetMessageText(string message)
    {
        MessageText.text = message;
    }
}