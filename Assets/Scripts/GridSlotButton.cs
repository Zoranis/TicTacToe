using System;
using DefaultNamespace;
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
        _button.onClick.AddListener(OnBtnClick);
    }

    private void OnBtnClick()
    {
        GameManager.Instance.SlotClicked(ButtonGridPosition);
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
