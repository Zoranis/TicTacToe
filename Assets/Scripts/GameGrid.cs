
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
    private const int GridSize = 3;

    public GameGrid()
    {
        m_GameSlots = new Mark[GridSize, GridSize];
    }

    public void InitializeSlot()
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
            LogManager.LogError("Slot location: " + gridPosition.Row + " , " + gridPosition.Col);
            return false;
        }

        m_GameSlots[gridPosition.Row, gridPosition.Col] = newValue;
        return true;
    }
}