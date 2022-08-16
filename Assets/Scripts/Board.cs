using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    [SerializeField] private Button gridSlotButton;
    [SerializeField] private List<GridSlotButton> SlotButtons;

    // Start is called before the first frame update
    void Start()
    {
        RenderBoard();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void RenderBoard()
    {
    }
}