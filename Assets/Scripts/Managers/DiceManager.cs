using System.Collections.Generic;
using Dice;
using UnityEngine;

namespace Managers
{
    public class DiceManager : MonoBehaviour
    {
        #region Singleton

        public static DiceManager Instance;

        private void Awake() => Instance = this;

        #endregion

        public List<DiceController> dice;

        public static int DiceCount;

        public void Initialize()
        {
            foreach (var die in dice)
            {
                die.gameObject.SetActive(true);
                die.diceManager = this;
            }
        }

        public void IndicateDice()
        {
            switch (GamePlayManager.CurrentPieceTurn)
            {
                case PieceType.Blue:
                    var diceControllerBlue = dice.FindIndex(controller => controller.pieceType == PieceType.Blue);
                    dice[diceControllerBlue].clickable = true;
                    dice[diceControllerBlue].Indicate(true);
                    break;
                case PieceType.Red:
                    var diceControllerRed = dice.FindIndex(controller => controller.pieceType == PieceType.Red);
                    dice[diceControllerRed].clickable = true;
                    dice[diceControllerRed].Indicate(true);
                    break;
                case PieceType.Green:
                    var diceControllerGreen = dice.FindIndex(controller => controller.pieceType == PieceType.Green);
                    dice[diceControllerGreen].clickable = true;
                    dice[diceControllerGreen].Indicate(true);
                    break;
                case PieceType.Yellow:
                    var diceControllerYellow = dice.FindIndex(controller => controller.pieceType == PieceType.Yellow);
                    dice[diceControllerYellow].clickable = true;
                    dice[diceControllerYellow].Indicate(true);
                    break;
            }
        }

        public void DiceRolled(int diceCount)
        {
            DiceCount = diceCount;
            PieceManager.Instance.IndicatePieces(DiceCount == 6);
        }
    }
}