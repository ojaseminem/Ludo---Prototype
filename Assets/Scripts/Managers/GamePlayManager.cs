using System;
using UnityEngine;

namespace Managers
{
    public class GamePlayManager : MonoBehaviour
    {
        #region Singleton

        public static GamePlayManager Instance;
        private void Awake() => Instance = this;

        #endregion

        public static PieceType CurrentPieceTurn = PieceType.Blue;

        public void ChangeTurn(PieceType pieceType)
        {
            if (pieceType == PieceType.ResetLoop)
                pieceType = PieceType.Blue;
            
            CurrentPieceTurn = pieceType;

            DiceManager.Instance.IndicateDice();
            PieceManager.Instance.ResetTurn();
        }
    }
}