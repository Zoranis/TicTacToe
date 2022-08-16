using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GridSlotButton : MonoBehaviour
{
    public GridPosition ButtonGridPosition;
    [SerializeField] private Text btnText;
    [SerializeField] private Button _button;


    private void Awake()
    {
        _button.onClick.AddListener(PlayerClick);
    }

    private void PlayerClick()
    {
        
    }

    public void Initialize(GridPosition gridPosition)
    {
        ButtonGridPosition = gridPosition;
    }
    
    public void SetText(string newText)
    {
        btnText.text = newText;
    }
    
}
