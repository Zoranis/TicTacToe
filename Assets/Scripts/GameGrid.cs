using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class GridSlot
{
    public int Col;
    public int Row;

    public MyStruct(int col, int row)
    {
        this.Col = col;
        this.Row = row;
    }
}

public class GameGrid
{
    private Mark[,] _mGameSlots;
    private const int GridSize = 3;

    public GameGrid()
    {
        _mGameSlots = new Mark[GridSize, GridSize];
    }

    public void InitializeSlot()
    {
        for (int i = 0; i < _mGameSlots.GetLength(0); i++)
        {
            for (int j = 0; j < _mGameSlots.GetLength(1); j++)
            {
                _mGameSlots[i, j] = Mark.Empty;
            }
        }
    }

    public Mark GetSlotValue(int row, int col)
    {
        return _mGameSlots[row, col];
    }

    public bool SetSlotValue(int row, int col, Mark newValue)
    {
        Mark targetSlotCurrentValue = GetSlotValue(row, col);

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

        _mGameSlots[row, col] = newValue;
        return true;
    }
}