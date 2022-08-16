using System.Collections;
using System.Collections.Generic;
using TicTacToe;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    [SerializeField] private Button gridSlotButton;
    [SerializeField] public List<GridSlotButton> SlotButtons;
    private const int GridSize = 3;


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

        int currentSlotIndex = 0;

        for (int i = 0; i < GridSize; i++)
        {
            for (int j = 0; j < GridSize; j++)
            {
                SlotButtons[currentSlotIndex].ButtonGridPosition = new GridPosition(i, j);
                SlotButtons[currentSlotIndex].SetText(i.ToString() + " " + j.ToString());
                currentSlotIndex++;
                
            }
        }

    }
}