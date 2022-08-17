using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace TicTacToe
{
    public class GameManager : MonoBehaviour
    {
        private GameGrid m_GameGrid;
        private Player[] m_Players;
        private int m_CurrentPlayerIndex;
        private UndoManager m_UndoManager;
        [SerializeField] private Board m_Board;
        [SerializeField] private StatusDisplay statusDisplay;
        private WinCondition _winCondition;
        private bool _gameOver = false;

        private Player CurrentPlayer => m_Players[m_CurrentPlayerIndex];

        public static GameManager Instance;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            m_GameGrid = new GameGrid();
            m_Players = new Player[2];
            m_UndoManager = new UndoManager();
            _winCondition = new WinCondition();
            InitializeGame();
        }

        public void Reset()
        {
            InitializeGame();
        }
        
        public bool SetMark(GridPosition gridPosition, Mark mark, bool isForceAction = false)
        {
            return m_GameGrid.SetSlotValue(gridPosition, mark, isForceAction);
        }

        private int GetRandomPlayerIndex()
        {
            return Random.Range(0, 2);
        }

        private int GetNextPlayerIndex()
        {
            return (m_CurrentPlayerIndex == 0) ? 1 : 0;
        }

        private void InitializeGame()
        {
            _gameOver = false;

            m_Players[0] = new Player("Player A");
            m_Players[1] = new Player("Player B");

            m_GameGrid.InitializeGrid();
            m_CurrentPlayerIndex = GetRandomPlayerIndex();
            m_Players[m_CurrentPlayerIndex].PlayerMark = Mark.X;
            m_Players[GetNextPlayerIndex()].PlayerMark = Mark.O;

            RefreshBoard();
        }

        private void SwitchTurns()
        {
            m_CurrentPlayerIndex = GetNextPlayerIndex();
        }

        private void RefreshBoard()
        {
            foreach (var slotButton in m_Board.SlotButtons)
            {
                Mark slotMark = m_GameGrid.GetSlotValue(slotButton.ButtonGridPosition);
                string markText = (slotMark == Mark.Empty) ? "" : slotMark.ToString();
                slotButton.SetText(markText);
            }

            statusDisplay.SetTurnText(CurrentPlayer.PlayerName);
            statusDisplay.SetMarkText(CurrentPlayer.PlayerMark.ToString());
        }

        public void SlotClicked(GridPosition gridPosition)
        {
            if (_gameOver)
            {
                statusDisplay.SetMessageText("Game Over, please reset.");
                return;
            }

            Mark currentPlayerMark = CurrentPlayer.PlayerMark;
            MarkCommand markCommand = new MarkCommand(currentPlayerMark, gridPosition);
            if (!markCommand.Execute())
            {
                Debug.Log("Illegal Move.");
            }


            if (_winCondition.IsMarkFinal(m_GameGrid, markCommand))
            {
                statusDisplay.SetMessageText(CurrentPlayer.PlayerName + " Wins!");
                _gameOver = true;
            }
            else
            {
                m_UndoManager.StackCommand(markCommand);
                SwitchTurns();
            }

            RefreshBoard();
        }

        public void Undo()
        {
            m_UndoManager.UndoLastCommand();
            RefreshBoard();
            SwitchTurns();
        }
    }
}