using System.Collections;
using System.Collections.Generic;
using Packages.Rider.Editor.UnitTesting;
using UnityEngine;
using UnityEngine.UI;

public class GridSlotButton : MonoBehaviour
{
    private GridPosition _gridPosition;
    private Text btnText;

    public void Initialize(GridPosition gridPosition)
    {
        _gridPosition = gridPosition;
    }
    
    public void SetText(string newText)
    {
        btnText.text = newText;
    }
    
}
