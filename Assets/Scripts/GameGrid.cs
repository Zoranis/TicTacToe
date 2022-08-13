using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameSlot
{
    X,
    O,
    Empty
}

public class GameGrid
{
    private GameSlot[,] m_GameSlots;
    private const int GridSize = 3;

    public GameGrid()
    {
        m_GameSlots = new GameSlot[GridSize, GridSize];
    }

    public void InitializeSlot()
    {
        for (int i = 0; i < m_GameSlots.GetLength(0); i++)
        {
            for (int j = 0; j < m_GameSlots.GetLength(1); j++)
            {
                m_GameSlots[i, j] = GameSlot.Empty;
            }
        }
    }

    public GameSlot GetSlotValue(int row, int col)
    {
        return m_GameSlots[row, col];
    }

    public bool SetSlotValue(int row, int col, GameSlot newValue)
    {
        GameSlot targetSlotCurrentValue = GetSlotValue(row, col);

        if (newValue == GameSlot.Empty)
        {
            LogManager.LogError("Cannot set slot value to empty.");
            return false;
        }
        else if (targetSlotCurrentValue != GameSlot.Empty)
        {
            LogManager.LogError("Cannot set value to a slot that isn't empty.");
            LogManager.LogError("Slot current value: " + targetSlotCurrentValue);
            LogManager.LogError("Slot location: " + row + " , " + col);
            return false;
        }

        m_GameSlots[row, col] = newValue;
        return true;
    }
}