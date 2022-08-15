using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GridPosition
{
    public int Col;
    public int Row;

    public GridPosition(int col, int row)
    {
        this.Col = col;
        this.Row = row;
    }
}

public class GameGrid
{
    private Mark[,] _GameSlots;
    private const int GridSize = 3;

    public GameGrid()
    {
        _GameSlots = new Mark[GridSize, GridSize];
    }

    public void InitializeSlot()
    {
        for (int i = 0; i < _GameSlots.GetLength(0); i++)
        {
            for (int j = 0; j < _GameSlots.GetLength(1); j++)
            {
                _GameSlots[i, j] = Mark.Empty;
            }
        }
    }

    public Mark GetSlotValue(GridPosition gridPosition)
    {
        return _GameSlots[gridPosition.Row, gridPosition.Col];
    }

    public bool SetSlotValue(GridPosition gridPosition, Mark newValue)
    {
        Mark targetSlotCurrentValue = GetSlotValue(gridPosition);

        if (newValue == Mark.Empty)
        {
            LogManager.LogError("Cannot set slot value to empty.");
            return false;
        }
        else if (targetSlotCurrentValue != Mark.Empty)
        {
            LogManager.LogError("Cannot set value to a slot that isn't empty.");
            LogManager.LogError("Slot current value: " + targetSlotCurrentValue);
            LogManager.LogError("Slot location: " + row + " , " + col);
            return false;
        }

        _GameSlots[gridPosition.Row, gridPosition.Col] = newValue;
        return true;
    }
}