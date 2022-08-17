using UnityEngine;

public struct GridPosition
{
    public readonly int Col;
    public readonly int Row;

    public GridPosition(int col, int row)
    {
        this.Col = col;
        this.Row = row;
    }
}

public class GameGrid
{
    private readonly Mark[,] m_GameSlots;
    public readonly int GridSize = 3;

    public GameGrid()
    {
        m_GameSlots = new Mark[GridSize, GridSize];
    }

    public void InitializeGrid()
    {
        for (int i = 0; i < m_GameSlots.GetLength(0); i++)
        {
            for (int j = 0; j < m_GameSlots.GetLength(1); j++)
            {
                m_GameSlots[i, j] = Mark.Empty;
            }
        }
    }

    public Mark GetSlotValue(GridPosition gridPosition)
    {
        return m_GameSlots[gridPosition.Row, gridPosition.Col];
    }

    public Mark GetSlotValue(int row, int col)
    {
        return m_GameSlots[row, col];
    }

    public bool SetSlotValue(GridPosition gridPosition, Mark newValue, bool isForceAction = false)
    {
        Mark targetSlotCurrentValue = GetSlotValue(gridPosition);

        // If target slot already has a mark, only an forced action can change it.
        if (!isForceAction && targetSlotCurrentValue != Mark.Empty)
        {
            LogManager.LogError("Only forced action can change an already marked slot.");
            return false;
        }

        m_GameSlots[gridPosition.Row, gridPosition.Col] = newValue;
        return true;
    }
}