using DG.Tweening;
using Managers;
using UnityEngine;

namespace Board
{
    public class Piece : MonoBehaviour
    {
        public bool clickable;
        public bool pieceLocked;

        public bool isPlayerControlled;
        public PlayerType playerType;
        
        public PieceType pieceType;

        public Cell currentCell;

        [SerializeField] private GameObject red, blue, green, yellow;

        public Tween indicationTween;

        public void ValidatePieceType(PieceType currPieceType)
        {
            pieceType = currPieceType;
            switch (pieceType)
            {
                case PieceType.Red:
                    red.SetActive(true);
                    break;
                case PieceType.Blue:
                    blue.SetActive(true);
                    break;
                case PieceType.Green:
                    green.SetActive(true);
                    break;
                case PieceType.Yellow:
                    yellow.SetActive(true);
                    break;
            }

            pieceLocked = true;
        }
        
        private void OnMouseDown()
        {
            if (!isPlayerControlled) return;
            if(!clickable) return;
            PieceManager.Instance.MovePiece(this);
        }
    }
}