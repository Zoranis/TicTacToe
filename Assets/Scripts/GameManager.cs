using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        private GameGrid _gameGrid;
        private Player[] _players;
        private int _currentPlayerIndex;

        public static GameManager Instance;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _gameGrid = new GameGrid();
            _players = new Player[2];
            InitializeGame();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.R))
            {
                InitializeGame();
            }
        }

        public void SetMark(GridPosition gridPosition, Mark mark)
        {
            _gameGrid.SetSlotValue(gridPosition, mark);
        }

        private int GetRandomPlayerIndex()
        {
            return Random.Range(0, 2);
        }

        private int GetNextPlayerIndex()
        {
            return (_currentPlayerIndex == 0) ? 1 : 0;
        }

        private void InitializeGame()
        {
            _gameGrid.InitializeGrid();
            _currentPlayerIndex = GetRandomPlayerIndex();
            _players[_currentPlayerIndex].PlayerMark = Mark.X;
            _players[GetNextPlayerIndex()].PlayerMark = Mark.O;
        }

        public void PlayerMarkSlot(GridPosition gridPosition)
        {
            Mark currentPlayerMark = _players[_currentPlayerIndex].PlayerMark;
            MarkCommand markCommand = new MarkCommand(currentPlayerMark, gridPosition);
        }
    }
}