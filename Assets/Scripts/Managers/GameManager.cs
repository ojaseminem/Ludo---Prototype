using System;
using Data;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        #region Singleton

        public static GameManager Instance;
        private void Awake() => Instance = this;

        #endregion

        #region Data

        public ResourceBank resourceBank;
        public LevelData levelData;

        #endregion

        #region Managers

        [SerializeField] private BoardManager boardManager;
        [SerializeField] private DiceManager diceManager;
        [SerializeField] private PieceManager pieceManager;
        
        #endregion

        private void Start()
        {
            ChangeGameState(GameStates.PreGame);
        }

        public void ChangeGameState(GameStates gameStates)
        {
            switch (gameStates)
            {
                case GameStates.PreGame: PreGame();
                    break;
                case GameStates.Playing: Playing();
                    break;
                case GameStates.Paused: Paused();
                    break;
                case GameStates.Won: Won();
                    break;
                case GameStates.Lost: Lost();
                    break;
                case GameStates.Quit: Quit();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameStates), gameStates, null);
            }
        }

        private void PreGame()
        {
            //Assign references
            boardManager.resourceBank = resourceBank;
            boardManager.SpawnBoard();

            CheckLevelData();
            
            void CheckLevelData()
            {
                boardManager.hcRed.Initialize(levelData.redActive, resourceBank.piece, HomeCellType.Red);
                boardManager.hcBlue.Initialize(levelData.blueActive, resourceBank.piece, HomeCellType.Blue);
                boardManager.hcGreen.Initialize(levelData.greenActive, resourceBank.piece, HomeCellType.Green);
                boardManager.hcYellow.Initialize(levelData.yellowActive, resourceBank.piece, HomeCellType.Yellow);
            }
            
            UIManager.Instance.SpawnUI(UITypes.StartScreen);
        }

        private void Playing()
        {
            diceManager.Initialize();
            pieceManager.AssignPlayer(PieceType.Red, levelData.isRedPlayerControlled, levelData.redPlayerType);
            pieceManager.AssignPlayer(PieceType.Blue, levelData.isBluePlayerControlled, levelData.bluePlayerType);
            pieceManager.AssignPlayer(PieceType.Green, levelData.isGreenPlayerControlled, levelData.greenPlayerType);
            pieceManager.AssignPlayer(PieceType.Yellow, levelData.isYellowPlayerControlled, levelData.yellowPlayerType);

            UIManager.Instance.SpawnUI(UITypes.PlayerDataScreen);
            UIManager.Instance.playerDataScreen.Initialize(levelData.bluePlayerType, levelData.redPlayerType, levelData.greenPlayerType, levelData.yellowPlayerType);
            
            GamePlayManager.Instance.ChangeTurn(PieceType.Blue);
        }

        private void Paused()
        {
            
        }

        private void Won()
        {
            
        }

        private void Lost()
        {
            
        }

        private void Quit()
        {
            //Todo go to main menu
        }
    }
}