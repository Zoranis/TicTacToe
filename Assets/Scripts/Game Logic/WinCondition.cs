
using UnityEngine;

namespace TicTacToe
{
    public class WinCondition
    {
        private GameGrid _gameGrid;

        // Is mark completing a set, and finishing the game
        public bool IsMarkFinal(GameGrid gameGrid, MarkCommand markCommand)
        {
            _gameGrid = gameGrid;
            
            Mark mark = markCommand.PlayerMark;
            int row = markCommand.GridPosition.Row;
            int col = markCommand.GridPosition.Col;

            if (IsMarkFullCol(col, mark))
                return true;
            if (IsMarkFullRow(row, mark))
                return true;
            if (IsMarkFullMainDiagonal(row, col, mark))
                return true;
            if (IsMarkFullAntiDiagonal(row, col, mark))
                return true;

            return false;
        }

        private bool IsMarkFullRow(int row, Mark mark)
        {
            for (int i = 0; i < _gameGrid.GridSize; i++)
            {
                if (_gameGrid.GetSlotValue(row, i) != mark)
                    return false;
            }
            return true;
        }

        private bool IsMarkFullCol(int col, Mark mark)
        {
            for (int i = 0; i < _gameGrid.GridSize; i++)
            {
                if (_gameGrid.GetSlotValue(i, col) != mark)
                    return false;
            }

            return true;
        }

        private bool IsMarkFullMainDiagonal(int row, int col, Mark mark)
        {
            if (row != col)
                return false;

            for (int i = 0; i < _gameGrid.GridSize; i++)
            {
                if (_gameGrid.GetSlotValue(i, i) != mark)
                    return false;
            }

            return true;
        }

        private bool IsMarkFullAntiDiagonal(int row, int col, Mark mark)
        {
            int lastIndex = _gameGrid.GridSize - 1;
            if (row != lastIndex - col)
                return false;

            for (int i = 0; i < _gameGrid.GridSize; i++)
            {
                if (_gameGrid.GetSlotValue(i, lastIndex - i) != mark)
                    return false;
            }

            return true;
        }
    }
}