using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        private GameGrid _gameGrid;


        private void Start()
        {
            _gameGrid = new GameGrid();
        }

        public void SetMark(GridPosition gridPosition, Mark mark)
        {
            _gameGrid.SetSlotValue(gridPosition, mark);
        }



    }
}