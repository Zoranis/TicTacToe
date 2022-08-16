using UnityEngine;
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
        private WinCondition _winCondition;

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

        private void Update()
        {
            if (Input.GetKey(KeyCode.R))
            {
                InitializeGame();
            }
        }

        public void SetMark(GridPosition gridPosition, Mark mark)
        {
            m_GameGrid.SetSlotValue(gridPosition, mark);
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
            m_Players[0] = new Player();
            m_Players[1] = new Player();

            m_GameGrid.InitializeGrid();
            m_CurrentPlayerIndex = GetRandomPlayerIndex();
            m_Players[m_CurrentPlayerIndex].PlayerMark = Mark.X;
            m_Players[GetNextPlayerIndex()].PlayerMark = Mark.O;
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
                slotButton.SetText(slotMark.ToString());
            }
        }

        public void SlotClicked(GridPosition gridPosition)
        {
            Mark currentPlayerMark = m_Players[m_CurrentPlayerIndex].PlayerMark;
            MarkCommand markCommand = new MarkCommand(currentPlayerMark, gridPosition);
            markCommand.Execute();
            
            if (_winCondition.IsMarkFinal(m_GameGrid, markCommand))
                Debug.Log("WIN");
            
            m_UndoManager.StackCommand(markCommand);
            RefreshBoard();
            SwitchTurns();
        }

        public void Undo()
        {
            m_UndoManager.UndoLastCommand();
            RefreshBoard();
        }
    }
}